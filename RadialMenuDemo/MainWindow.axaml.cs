using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.ReactiveUI;

namespace RadialMenuDemo;

public partial class MainWindow : ReactiveWindow<MainViewModel>
{
    private readonly MainViewModel _mvm;

    
public MainWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        _mvm = new MainViewModel();
        DataContext = _mvm;
    }
    
    private Point GetCenterOfRadialMenu(Point p)
    {
        if (radialMenu.MenuContent is null || radialMenu.MenuContent.Count == 0)
            throw new Exception("Invalid: RadialMenu has 0 Items, Add Items to RadialMenu then try again");
        
        var rad = radialMenu.MenuContent[0].OuterRadius;
        return new Point(p.X - rad, p.Y - rad);
    }
    
    private void Canvas_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var c = sender as Canvas;
        var curPoint = e.GetCurrentPoint(c);
        
        if (curPoint.Properties.IsRightButtonPressed && !_mvm.IsOpen)
        {
            _mvm.Location = GetCenterOfRadialMenu(curPoint.Position);
            _mvm.IsOpen = true;
        }
        else if (e.GetCurrentPoint(canvas).Properties.IsLeftButtonPressed && _mvm.IsOpen)
        {
            _mvm.IsOpen = false;
        }
    }
}