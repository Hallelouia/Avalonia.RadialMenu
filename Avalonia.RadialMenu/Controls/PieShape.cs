using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Avalonia.Platform;

namespace Avalonia.RadialMenu.Controls;

internal class PieShape : Shape
{
    public static readonly StyledProperty<double> InnerRadiusProperty =
        AvaloniaProperty.Register<PieShape, double>(nameof(InnerRadius));

    public static readonly StyledProperty<double> OuterRadiusProperty =
        AvaloniaProperty.Register<PieShape, double>(nameof(OuterRadius));

    public static readonly StyledProperty<double> PaddingProperty =
        AvaloniaProperty.Register<PieShape, double>(nameof(Padding));

    public static readonly StyledProperty<double> PushOutProperty =
        AvaloniaProperty.Register<PieShape, double>(nameof(PushOut));

    public static readonly StyledProperty<double> AngleDeltaProperty =
        AvaloniaProperty.Register<PieShape, double>(nameof(AngleDelta));

    public static readonly StyledProperty<double> StartAngleProperty =
        AvaloniaProperty.Register<PieShape, double>(nameof(StartAngle));

    public static readonly StyledProperty<double> CenterXProperty =
        AvaloniaProperty.Register<PieShape, double>(nameof(CenterX));

    public static readonly StyledProperty<double> CenterYProperty =
        AvaloniaProperty.Register<PieShape, double>(nameof(CenterY));

    static PieShape()
    {
        AffectsGeometry<PieShape>(StartAngleProperty, AngleDeltaProperty, PaddingProperty, CenterXProperty,
            CenterYProperty, InnerRadiusProperty, OuterRadiusProperty, PushOutProperty, HeightProperty, WidthProperty);
    }

    /// <summary>
    ///     The inner radius of this pie piece
    /// </summary>
    public double InnerRadius
    {
        get => GetValue(InnerRadiusProperty);
        set => SetValue(InnerRadiusProperty, value);
    }

    /// <summary>
    ///     The outer radius of this pie piece
    /// </summary>
    public double OuterRadius
    {
        get => GetValue(OuterRadiusProperty);
        set => SetValue(OuterRadiusProperty, value);
    }

    /// <summary>
    ///     The padding arround this pie piece
    /// </summary>
    public double Padding
    {
        get => GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }

    /// <summary>
    ///     The distance to 'push' this pie piece out from the center
    /// </summary>
    public double PushOut
    {
        get => GetValue(PushOutProperty);
        set => SetValue(PushOutProperty, value);
    }

    /// <summary>
    ///     The angle delta of this pie piece in degrees
    /// </summary>
    public double AngleDelta
    {
        get => GetValue(AngleDeltaProperty);
        set => SetValue(AngleDeltaProperty, value);
    }

    /// <summary>
    ///     The start angle from the Y axis vector of this pie piece in degrees
    /// </summary>
    public double StartAngle
    {
        get => GetValue(StartAngleProperty);
        set => SetValue(StartAngleProperty, value);
    }

    /// <summary>
    ///     The X coordinate of center of the circle from which this pie piece is cut
    /// </summary>
    public double CenterX
    {
        get => GetValue(CenterXProperty);
        set => SetValue(CenterXProperty, value);
    }

    /// <summary>
    ///     The Y coordinate of center of the circle from which this pie piece is cut
    /// </summary>
    public double CenterY
    {
        get => GetValue(CenterYProperty);
        set => SetValue(CenterYProperty, value);
    }

    /// <summary>
    ///     Defines the shape
    /// </summary>
    protected override Geometry? CreateDefiningGeometry()
    {
        var geometry = new StreamGeometry();
        using var context = geometry.Open();
        DrawGeometry(context);

        return geometry;
    }

    /// <summary>
    ///     Draws the pie piece
    /// </summary>
    private void DrawGeometry(IGeometryContext context)
    {
        if (AngleDelta <= 0) return;

        var outerStartAngle = StartAngle;
        var outerAngleDelta = AngleDelta;
        var innerStartAngle = StartAngle;
        var innerAngleDelta = AngleDelta;
        var arcCenter = new Point(CenterX, CenterY);
        var outerArcSize = new Size(OuterRadius, OuterRadius);
        var innerArcSize = new Size(InnerRadius, InnerRadius);

        // If have to draw a full-circle, draws two semi-circles, because 'ArcTo()' can not draw a full-circle
        if (AngleDelta >= 360 && Padding <= 0)
        {
            var outerArcTopPoint = ComputeCartesianCoordinate(arcCenter, outerStartAngle, OuterRadius + PushOut);
            var outerArcBottomPoint =
                ComputeCartesianCoordinate(arcCenter, outerStartAngle + 180, OuterRadius + PushOut);
            var innerArcTopPoint = ComputeCartesianCoordinate(arcCenter, innerStartAngle, InnerRadius + PushOut);
            var innerArcBottomPoint =
                ComputeCartesianCoordinate(arcCenter, innerStartAngle + 180, InnerRadius + PushOut);

            context.BeginFigure(innerArcTopPoint);
            context.LineTo(outerArcTopPoint);
            context.ArcTo(outerArcBottomPoint, outerArcSize, 0, false, SweepDirection.Clockwise);
            context.ArcTo(outerArcTopPoint, outerArcSize, 0, false, SweepDirection.Clockwise);
            context.LineTo(innerArcTopPoint);
            context.ArcTo(innerArcBottomPoint, innerArcSize, 0, false, SweepDirection.CounterClockwise);
            context.ArcTo(innerArcTopPoint, innerArcSize, 0, false, SweepDirection.CounterClockwise);
        }
        // Else draws as always
        else
        {
            if (Padding > 0)
            {
                // Offsets the angle by the padding
                var outerAngleVariation = 180 * (Padding / OuterRadius) / Math.PI;
                var innerAngleVariation = 180 * (Padding / InnerRadius) / Math.PI;

                outerStartAngle += outerAngleVariation;
                outerAngleDelta -= outerAngleVariation * 2;
                innerStartAngle += innerAngleVariation;
                innerAngleDelta -= innerAngleVariation * 2;
            }

            var outerArcStartPoint = ComputeCartesianCoordinate(arcCenter, outerStartAngle, OuterRadius + PushOut);
            var outerArcEndPoint =
                ComputeCartesianCoordinate(arcCenter, outerStartAngle + outerAngleDelta, OuterRadius + PushOut);
            var innerArcStartPoint = ComputeCartesianCoordinate(arcCenter, innerStartAngle, InnerRadius + PushOut);
            var innerArcEndPoint =
                ComputeCartesianCoordinate(arcCenter, innerStartAngle + innerAngleDelta, InnerRadius + PushOut);

            var largeArcOuter = outerAngleDelta > 180.0;
            var largeArcInner = innerAngleDelta > 180.0;

            context.BeginFigure(innerArcStartPoint);
            context.LineTo(outerArcStartPoint);
            context.ArcTo(outerArcEndPoint, outerArcSize, 0, largeArcOuter, SweepDirection.Clockwise);
            context.LineTo(innerArcEndPoint);
            context.ArcTo(innerArcStartPoint, innerArcSize, 0, largeArcInner, SweepDirection.CounterClockwise);
        }
    }

    private static Point ComputeCartesianCoordinate(Point center, double angle, double radius)
    {
        // Converts to radians
        var radiansAngle = Math.PI / 180.0 * (angle - 90);
        var x = radius * Math.Cos(radiansAngle);
        var y = radius * Math.Sin(radiansAngle);
        return new Point(x + center.X, y + center.Y);
    }
}