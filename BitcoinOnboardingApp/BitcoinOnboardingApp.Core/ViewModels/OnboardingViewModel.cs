using System.Collections.Generic;
using System.Threading.Tasks;
using BitcoinOnboardingApp.Core.ViewModels.Items;
using MvvmCross.ViewModels;

namespace BitcoinOnboardingApp.Core.ViewModels
{
    public class OnboardingViewModel : MvxViewModel
    {
        public OnboardingViewModel()
        {
        }

        public override Task Initialize()
        {
            this.AddIntroductionItems();

            return base.Initialize();
        }

        //Properties
        public List<OnboardingItemViewModel> IntroductionItems { get; set; } = new List<OnboardingItemViewModel>();

        private void AddIntroductionItems()
        {
            this.IntroductionItems.Add(new OnboardingItemViewModel("Take  a photo", "with your phone or camera", "ic_take_photo"));
            this.IntroductionItems.Add(new OnboardingItemViewModel("Join", "to our network", "ic_network"));
            this.IntroductionItems.Add(new OnboardingItemViewModel("And", "make money!", "ic_make_money"));
        }
    }
}
