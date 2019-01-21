namespace BitcoinOnboardingApp.Core.ViewModels.Items
{
    public class IntroductionItemViewModel
    {
        public IntroductionItemViewModel(string topText, string endText, string imagePath)
        {
            this.TopText = topText;
            this.EndText = endText;
            this.ImagePath = imagePath;
        }

        public string TopText { get; set; }

        public string EndText { get; set; }

        public string ImagePath { get; set; }
    }
}
