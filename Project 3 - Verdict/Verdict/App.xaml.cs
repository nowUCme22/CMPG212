using VerdictProject3;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
using WinRT.Interop;
#endif

namespace VerdictProject3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //open welcomepage as main page
            MainPage = new NavigationPage(new WelcomePage());

#if WINDOWS
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(App), (handler, view) =>
            {
                var nativeWindow = handler.PlatformView;
                var windowHandle = WindowNative.GetWindowHandle(nativeWindow);

                var windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
                var appWindow = AppWindow.GetFromWindowId(windowId);

                var displayArea = DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Primary);
                appWindow.MoveAndResize(displayArea.WorkArea);
            });
#endif
        }
    }
}
