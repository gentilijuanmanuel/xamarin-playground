using System.Collections.Generic;
using System.Threading.Tasks;
using BitcoinOnboardingApp.Core.ViewModels.Items;
using MvvmCross.ViewModels;

namespace BitcoinOnboardingApp.Core.ViewModels
{
    public class OnboardingViewModel : MvxViewModel
    {
        //Mvx life-cycle
        public override Task Initialize()
        {
            this.AddIntroductionItems();

            return base.Initialize();
        }

        //Properties
        public List<OnboardingItemViewModel> IntroductionItems { get; set; } = new List<OnboardingItemViewModel>();

        private void AddIntroductionItems()
        {
            this.IntroductionItems.Add(new OnboardingItemViewModel("Take a photo...", "...with your phone", "ic_camera.json"));
            this.IntroductionItems.Add(new OnboardingItemViewModel("Join...", "...to our network", "ic_network.json"));
            this.IntroductionItems.Add(new OnboardingItemViewModel("", "...and make money!", "ic_money.json"));
        }
    }
}
