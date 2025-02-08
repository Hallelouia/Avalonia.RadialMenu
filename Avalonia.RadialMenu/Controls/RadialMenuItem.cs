using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia.Styling;

namespace Avalonia.RadialMenu.Controls;

/// <summary>
/// Interaction logic for RadialMenuItem.xaml
/// </summary>
public class RadialMenuItem : Button
{
    public static readonly StyledProperty<int> IndexProperty =
        AvaloniaProperty.Register<RadialMenuItem, int>(nameof(Index), 0, false, BindingMode.Default, null, null, false);

    public int Index
    {
        get => GetValue(IndexProperty);
        set => SetValue(IndexProperty, value);
    }

    public static readonly StyledProperty<int> CountProperty =
        AvaloniaProperty.Register<RadialMenuItem, int>(nameof(Count), 1, false, BindingMode.Default, null, null, false);

    public int Count
    {
        get => GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }

    public static readonly StyledProperty<bool> HalfShiftedProperty =
        AvaloniaProperty.Register<RadialMenuItem, bool>(nameof(HalfShifted), false, false, BindingMode.Default, null,
            null, false);

    public bool HalfShifted
    {
        get => GetValue(HalfShiftedProperty);
        set => SetValue(HalfShiftedProperty, value);
    }


    public static readonly StyledProperty<double> CenterXProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(CenterX), 0);

    public double CenterX
    {
        get => GetValue(CenterXProperty);
        set => SetValue(CenterXProperty, value);
    }

    public static readonly StyledProperty<double> CenterYProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(CenterY), 0);

    public double CenterY
    {
        get => GetValue(CenterYProperty);
        set => SetValue(CenterYProperty, value);
    }

    public static readonly StyledProperty<double> OuterRadiusProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(OuterRadius), 0);

    public double OuterRadius
    {
        get => GetValue(OuterRadiusProperty);
        set => SetValue(OuterRadiusProperty, value);
    }

    public static readonly StyledProperty<double> InnerRadiusProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(InnerRadius), 0);

    public double InnerRadius
    {
        get => GetValue(InnerRadiusProperty);
        set => SetValue(InnerRadiusProperty, value);
    }

    public new static readonly StyledProperty<double> PaddingProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(Padding), 0);

    public new double Padding
    {
        get => GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }

    public static readonly StyledProperty<double> ContentRadiusProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(ContentRadius), 0);

    public double ContentRadius
    {
        get => GetValue(ContentRadiusProperty);
        set => SetValue(ContentRadiusProperty, value);
    }

    public static readonly StyledProperty<double> EdgeOuterRadiusProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(EdgeOuterRadius), 0);

    public double EdgeOuterRadius
    {
        get => GetValue(EdgeOuterRadiusProperty);
        set => SetValue(EdgeOuterRadiusProperty, value);
    }

    public static readonly StyledProperty<double> EdgeInnerRadiusProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(EdgeInnerRadius), 0);

    public double EdgeInnerRadius
    {
        get => GetValue(EdgeInnerRadiusProperty);
        set => SetValue(EdgeInnerRadiusProperty, value);
    }

    public static readonly StyledProperty<double> EdgePaddingProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(EdgePadding), 0);

    public double EdgePadding
    {
        get => GetValue(EdgePaddingProperty);
        set => SetValue(EdgePaddingProperty, value);
    }

    public static readonly StyledProperty<IBrush?> EdgeBackgroundProperty =
        AvaloniaProperty.Register<RadialMenuItem, IBrush?>(nameof(EdgeBackground), null);

    public IBrush? EdgeBackground
    {
        get => GetValue(EdgeBackgroundProperty);
        set => SetValue(EdgeBackgroundProperty, value);
    }

    public static readonly StyledProperty<double> EdgeBorderThicknessProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(EdgeBorderThickness), 0);

    public double EdgeBorderThickness
    {
        get => GetValue(EdgeBorderThicknessProperty);
        set => SetValue(EdgeBorderThicknessProperty, value);
    }

    public static readonly StyledProperty<IBrush?> EdgeBorderBrushProperty =
        AvaloniaProperty.Register<RadialMenuItem, IBrush?>(nameof(EdgeBorderBrush), null);

    public IBrush? EdgeBorderBrush
    {
        get => GetValue(EdgeBorderBrushProperty);
        set => SetValue(EdgeBorderBrushProperty, value);
    }

    public static readonly StyledProperty<IBrush?> ArrowBackgroundProperty =
        AvaloniaProperty.Register<RadialMenuItem, IBrush?>(nameof(ArrowBackground), null);

    public IBrush? ArrowBackground
    {
        get => GetValue(ArrowBackgroundProperty);
        set => SetValue(ArrowBackgroundProperty, value);
    }

    public static readonly StyledProperty<double> ArrowBorderThicknessProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(ArrowBorderThickness), 0);

    public double ArrowBorderThickness
    {
        get => GetValue(ArrowBorderThicknessProperty);
        set => SetValue(ArrowBorderThicknessProperty, value);
    }

    public static readonly StyledProperty<IBrush?> ArrowBorderBrushProperty =
        AvaloniaProperty.Register<RadialMenuItem, IBrush?>(nameof(ArrowBorderBrush), null);

    public IBrush? ArrowBorderBrush
    {
        get => GetValue(ArrowBorderBrushProperty);
        set => SetValue(ArrowBorderBrushProperty, value);
    }

    public static readonly StyledProperty<double> ArrowWidthProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(ArrowWidth), 0);

    public double ArrowWidth
    {
        get => GetValue(ArrowWidthProperty);
        set => SetValue(ArrowWidthProperty, value);
    }

    public static readonly StyledProperty<double> ArrowHeightProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(ArrowHeight), 0);

    public double ArrowHeight
    {
        get => GetValue(ArrowHeightProperty);
        set => SetValue(ArrowHeightProperty, value);
    }

    public static readonly StyledProperty<double> ArrowRadiusProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(ArrowRadius), 0);

    public double ArrowRadius
    {
        get => GetValue(ArrowRadiusProperty);
        set => SetValue(ArrowRadiusProperty, value);
    }

    public static readonly StyledProperty<double> AngleDeltaProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(AngleDelta), 200);

    public double AngleDelta
    {
        get => GetValue(AngleDeltaProperty);
        set => SetValue(AngleDeltaProperty, value);
    }

    public static readonly StyledProperty<double> StartAngleProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(StartAngle), 0);

    public double StartAngle
    {
        get => GetValue(StartAngleProperty);
        set => SetValue(StartAngleProperty, value);
    }

    public static readonly StyledProperty<double> RotationProperty =
        AvaloniaProperty.Register<RadialMenuItem, double>(nameof(Rotation), 0);

    public double Rotation
    {
        get => GetValue(RotationProperty);
        set => SetValue(RotationProperty, value);
    }

    static RadialMenuItem()
    {
        AffectsArrange<RadialMenuItem>(IndexProperty);
        AffectsArrange<RadialMenuItem>(CountProperty);
        AffectsArrange<RadialMenuItem>(HalfShiftedProperty);
    }

    protected override void ArrangeCore(Rect finalRect)
    {
        var angleDelta = 360.0 / Count;
        var angleShift = HalfShifted ? -angleDelta / 2 : 0;
        var startAngle = angleDelta * Index + angleShift;
        var rotation = startAngle + angleDelta / 2;

        AngleDelta = angleDelta;
        StartAngle = startAngle;
        Rotation = rotation;

        base.ArrangeCore(finalRect);
    }
}