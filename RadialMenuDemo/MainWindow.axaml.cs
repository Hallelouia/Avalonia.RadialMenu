using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.RadialMenu.Controls;

namespace RadialMenuDemo;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    private readonly MainViewModel _mvm;
    private readonly RadialMenu _r;
    private readonly Canvas _c;

    public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
        _r = this.FindControl<RadialMenu>("radialMenu");
        _c = this.FindControl<Canvas>("canvas");

        _mvm = new MainViewModel();
        DataContext = _mvm;
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private Point GetCenterOfRadialMenu(Point p)
    {
        if (_r.Content is null || _r.Content.Count == 0)
            throw new Exception("Invalid: RadialMenu has 0 Items, Add Items to RadialMenu then try again");
        
        var rad = _r.Content[0].OuterRadius;
        return new Point(p.X - rad, p.Y - rad);
    }

    private void Canvas_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var c = sender as Canvas;
        var cur_point = e.GetCurrentPoint(c);
        
        if (cur_point.Properties.IsRightButtonPressed && !_mvm.IsOpen)
        {
            _mvm.Location = GetCenterOfRadialMenu(cur_point.Position);
            _mvm.IsOpen = true;
        }
        else if (e.GetCurrentPoint(_c).Properties.IsLeftButtonPressed && _mvm.IsOpen)
        {
            _mvm.IsOpen = false;
        }
    }
}