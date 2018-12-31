using System.Threading.Tasks;
using Xamarin.Forms;

namespace XAMLPractice
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void PartOneButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PartOnePage());
        }

        private async void PartTwoButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PartTwoPage());
        }

        private async void PartThreeButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PartThreePage());
        }

        private async void PartFourButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PartFourPage());
        }

        private async void PartFiveButtonClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PartFivePage());
        }
    }
}
