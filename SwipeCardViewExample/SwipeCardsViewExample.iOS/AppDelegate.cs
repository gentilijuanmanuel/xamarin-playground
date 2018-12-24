using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using SwipeCardViewExample.Core;
using SwipeCardViewExample.Forms.UI;
using UIKit;

namespace SwipeCardsViewExample.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<App, FormsApp>, App, FormsApp>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            FormsApp.ScreenWidth = UIScreen.MainScreen.Bounds.Width;
            FormsApp.ScreenHeight = UIScreen.MainScreen.Bounds.Height;

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}
