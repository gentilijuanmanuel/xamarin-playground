using BitcoinOnboardingApp.Core.ViewModels;
using MvvmCross.ViewModels;

namespace BitcoinOnboardingApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<OnboardingViewModel>();
        }
    }
}
