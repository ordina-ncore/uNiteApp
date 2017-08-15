using Xamarin.Forms;
using PlatformEffects = Ordina.Ncore.Unite.UWP.Effects;
using Xamarin.Forms.Platform.UWP;
using Windows.UI.Xaml;
using Ordina.Ncore.Unite.Effects;

[assembly: ExportEffect(typeof(PlatformEffects.ClickableHoverEffect), EffectIds.ClickableHoverEffectName)]
namespace Ordina.Ncore.Unite.UWP.Effects
{
    public class ClickableHoverEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if(Control is UIElement uiElement)
            {
                uiElement.PointerEntered += UiElement_PointerEntered;
                uiElement.PointerExited += UiElement_PointerExited;
            }
        }

        private void UiElement_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 0);
        }

        private void UiElement_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            if(e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Mouse)
            {
                Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 0);
            }
        }

        protected override void OnDetached()
        {
            if (Control is UIElement uiElement)
            {
                uiElement.PointerEntered -= UiElement_PointerEntered;
                uiElement.PointerExited -= UiElement_PointerExited;
            }
        }
    }
}
