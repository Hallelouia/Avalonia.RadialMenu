using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;

namespace Avalonia.RadialMenu.Converters;

internal class RadialMenuItemToArrowPosition : IMultiValueConverter
{
    public object Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if (values.Any(v => v is UnsetValueType)) return new Point(0, 0);

        if (values.Count != 5)
            throw new ArgumentException(
                "RadialMenuItemToArrowPosition converter needs 5 values (double centerX, double centerY, double arrowWidth, double arrowHeight, double arrowRadius) !",
                "values");
        if (parameter == null)
            throw new ArgumentNullException("parameter",
                "RadialMenuItemToArrowPosition converter needs the parameter (string axis) !");

        var axis = (string)parameter;

        if (axis != "X" && axis != "Y")
            throw new ArgumentException("RadialMenuItemToArrowPosition parameter needs to be 'X' or 'Y' !",
                "parameter");

        double? centerX = (double)(values[0] ?? 0);
        double? centerY = (double)(values[1] ?? 0);
        double? arrowWidth = (double)(values[2] ?? 0);
        double? arrowHeight = (double)(values[3] ?? 0);
        double? arrowRadius = (double)(values[4] ?? 0);

        if (axis == "X") return centerX - arrowWidth / 2;

        return centerY - arrowRadius - arrowHeight / 2;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new InvalidOperationException("RadialMenuItemToArrowPosition is a One-Way converter only !");
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