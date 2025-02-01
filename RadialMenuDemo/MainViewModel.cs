using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using ReactiveUI;

namespace RadialMenuDemo;

public class MainViewModel : ReactiveObject
{
    List<Button> _buttons = new List<Button>() { new Button() {Content = "A"}, new Button() {Content = "A"}, new Button() {Content = "A"}, new Button() {Content = "A"}, new Button() {Content = "A"}, };

    
    List<Button> Buttons => _buttons;

    private ReactiveCommand<Unit, Unit> CloseRadialMenu { get; }
    private ReactiveCommand<Unit, Unit> OpenRadialMenu { get; }

    private ReactiveCommand<string, Unit> Pressed { get; }

    private Point _location;

    public Point Location
    {
        get => _location;
        set => this.RaiseAndSetIfChanged(ref _location, value);
    }

    private bool _isOpen = false;

    public bool IsOpen
    {
        get => _isOpen;
        set => this.RaiseAndSetIfChanged(ref _isOpen, value);
    }

    private bool _isShifted = false;
    public bool IsShifted
    {
        get => _isShifted;
        set => this.RaiseAndSetIfChanged(ref _isShifted, value);
    }

    private string _lastPressed;

    private string LastPressed
    {
        get => _lastPressed;
        set => this.RaiseAndSetIfChanged(ref _lastPressed, value);
    }

    public MainViewModel() : base()
    {
        OpenRadialMenu = ReactiveCommand.Create(OpenMenu);
        CloseRadialMenu = ReactiveCommand.Create(CloseMenu);

        Pressed = ReactiveCommand.Create<string>(WritePieceNb);

        _lastPressed = "None";
    }

    public void OpenMenu()
    {
        IsOpen = true;
    }

    public void CloseMenu()
    {
        IsOpen = false;
    }

    private void WritePieceNb(string nb)
    {
        Console.WriteLine($"Pressed Piece #{nb}.");
        LastPressed = nb;
    }
}