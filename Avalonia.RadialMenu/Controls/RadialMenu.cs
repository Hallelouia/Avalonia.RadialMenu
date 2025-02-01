using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Styling;

namespace Avalonia.RadialMenu.Controls;

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
        
        public static readonly StyledProperty<List<RadialMenuItem>?> MenuContentProperty =
            AvaloniaProperty.Register<RadialMenu, List<RadialMenuItem>?>(nameof(MenuContent), null);
        public List<RadialMenuItem>? MenuContent
        {
            get => GetValue(MenuContentProperty);
            set => SetValue(MenuContentProperty, value);
        }

        static RadialMenu()
        {
        }

        public override void BeginInit()
        {
            MenuContent = new List<RadialMenuItem>();
            base.BeginInit();
        }

        public override void Render(DrawingContext context)
        {
            for (int i = 0, count = MenuContent!.Count; i < count; i++)
            {
                MenuContent[i].Index = i;
                MenuContent[i].Count = count;
                MenuContent[i].HalfShifted = HalfShiftedItems;
            }
            base.Render(context);
        }
    }