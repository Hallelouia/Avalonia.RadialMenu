using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using RadialMenu.Controls;
using ReactiveUI;
using Brush = Avalonia.Media.Brush;
using Brushes = Avalonia.Media.Brushes;
using Color = System.Drawing.Color;

namespace RadialMenuDemo
{
    public partial class MainWindow : Window, INotifyPropertyChanged
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
        
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
        
        protected override void OnPointerPressed(PointerPressedEventArgs e)
        {
            base.OnPointerPressed(e);
            if (e.GetCurrentPoint(null).Properties.IsRightButtonPressed  && !_mvm.IsOpen)
            {
                _mvm.OpenMenu();
            }
        }
    }
}