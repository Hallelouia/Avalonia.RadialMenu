using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;

namespace RadialMenu.Controls;

   public class RadialMenu : ContentControl
    {
        public static readonly StyledProperty<bool> IsOpenProperty =
            AvaloniaProperty.Register<RadialMenu, bool>(nameof(IsOpen), false);
            
        public bool IsOpen
        {
            get => GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }
        public static readonly StyledProperty<bool> HalfShiftedItemsProperty =
            AvaloniaProperty.Register<RadialMenu, bool>(nameof(HalfShiftedItems), false);
        
        public bool HalfShiftedItems
        {
            get => GetValue(HalfShiftedItemsProperty);
            set => SetValue(HalfShiftedItemsProperty, value);
        }

        public static readonly StyledProperty<RadialMenuCentralItem?> CentralItemProperty =
            AvaloniaProperty.Register<RadialMenu, RadialMenuCentralItem?>(nameof(CentralItem), null);
        public RadialMenuCentralItem? CentralItem
        {
            get => GetValue(CentralItemProperty);
            set => SetValue(CentralItemProperty, value);
        }
        
        public new static readonly StyledProperty<List<RadialMenuItem>?> ContentProperty =
            AvaloniaProperty.Register<RadialMenu, List<RadialMenuItem>?>(nameof(Content), null);
        public new List<RadialMenuItem>? Content
        {
            get => GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        static RadialMenu()
        {
        }

        public override void BeginInit()
        {
            Content = new List<RadialMenuItem>();
            base.BeginInit();
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            for (int i = 0, count = Content!.Count; i < count; i++)
            {
                Content[i].Index = i;
                Content[i].Count = count;
                Content[i].HalfShifted = HalfShiftedItems;
            }
            return base.ArrangeOverride(arrangeSize);
        }
    }