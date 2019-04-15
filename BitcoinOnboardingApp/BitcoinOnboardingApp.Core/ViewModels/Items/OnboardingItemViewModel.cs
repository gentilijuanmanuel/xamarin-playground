namespace BitcoinOnboardingApp.Core.ViewModels.Items
{
    public class OnboardingItemViewModel
    {
        public OnboardingItemViewModel(string topText, string endText, string animationPath)
        {
            this.TopText = topText;
            this.EndText = endText;
            this.AnimationPath = animationPath;
        }

        public string TopText { get; set; }

        public string EndText { get; set; }

        public string AnimationPath { get; set; }
    }
}
