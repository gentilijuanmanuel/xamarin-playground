using BitcoinOnboardingApp.Core.ViewModels;
using MvvmCross.Forms.Views;

namespace BitcoinOnboardingApp.UI.Views
{
    public partial class OnboardingView : MvxContentPage<OnboardingViewModel>
    {
        public OnboardingView()
        {
            InitializeComponent();
        }

        private void ShowPopUp(object sender, System.EventArgs e) => DisplayAlert("Hello!", "Not implemented yet :(", "Ok");
    }
}