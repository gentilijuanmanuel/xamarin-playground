using System.Collections.Generic;
using System.ComponentModel;
using RoundedCornersCardsExample.ViewModels;
using RoundedCornersCardsExample.ViewModels.Items;
using Xamarin.Forms;

namespace RoundedCornersCardsExample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var viewModel = new MainViewModel
            {
                Cards = new List<Card>
                {
                    new Card { Title = "Card 1" },
                    new Card { Title = "Card 2" },
                    new Card { Title = "Card 3" },
                    new Card { Title = "Card 4" },
                    new Card { Title = "Card 5" },
                    new Card { Title = "Card 6" }
                }
            };

            this.BindingContext = viewModel;
        }
    }
}
