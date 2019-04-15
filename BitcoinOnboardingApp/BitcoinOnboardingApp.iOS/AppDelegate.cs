using CarouselView.FormsPlugin.iOS;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using MvvmCross.Forms.Platforms.Ios.Core;
using UIKit;

namespace BitcoinOnboardingApp.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<Core.App, UI.App>, Core.App, UI.App>
    { 
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            global::Xamarin.Forms.Forms.Init();

            CarouselViewRenderer.Init();
            AnimationViewRenderer.Init();

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}

