using Android.App;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Forms.Platforms.Android.Core;
using Android.Content.PM;
using CarouselView.FormsPlugin.Android;
using Lottie.Forms.Droid;

namespace BitcoinOnboardingApp.Droid
{
    [Activity(
        Label = "BitcoinOnboardingApp.Droid",
        Theme = "@style/MyTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTask)]
    public class MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<Core.App, UI.App>, Core.App, UI.App>
    {
        protected override void OnCreate(Bundle bundle)
        {
            global::Xamarin.Forms.Forms.Init(this, bundle);

            CarouselViewRenderer.Init();
            AnimationViewRenderer.Init();

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
        }
    }
}

