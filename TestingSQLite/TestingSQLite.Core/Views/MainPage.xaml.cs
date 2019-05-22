using TestingSQLite.Core.ViewModels;
using Xamarin.Forms;

namespace TestingSQLite.Core.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            this.BindingContext = viewModel;
        }
    }
}
