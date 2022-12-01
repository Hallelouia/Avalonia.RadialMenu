using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;

namespace RadialMenuDemo;

public class MainViewModel : ReactiveObject
{
    public MainViewModel() : base()
    {
        OpenRadialMenu = ReactiveCommand.Create(OpenMenu);
        CloseRadialMenu = ReactiveCommand.Create(CloseMenu);
    }

    public void OpenMenu()
    {
        IsOpen = true;
    }

    public void CloseMenu()
    {
        IsOpen = false;
    }
    
    private bool _isOpen = false;

    public bool IsOpen
    {
        get { return _isOpen; }
        set
        {
            this.RaiseAndSetIfChanged(ref _isOpen, value );
        }
    }

    public ReactiveCommand<Unit, Unit> CloseRadialMenu { get; }

    public ReactiveCommand<Unit, Unit> OpenRadialMenu { get; }
}