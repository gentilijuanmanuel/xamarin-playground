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
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
