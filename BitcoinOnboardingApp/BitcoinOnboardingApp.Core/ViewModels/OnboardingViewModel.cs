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
        public List<IntroductionItemViewModel> IntroductionItems { get; set; } = new List<IntroductionItemViewModel>();

        private void AddIntroductionItems()
        {
            this.IntroductionItems.Add(new IntroductionItemViewModel("Take  a photo", "with your phone or camera", "ic_take_photo"));
            this.IntroductionItems.Add(new IntroductionItemViewModel("Join", "to our network", "ic_network"));
            this.IntroductionItems.Add(new IntroductionItemViewModel("And", "make money!", "ic_make_money"));
        }
    }
}
