using OfflineFirstPOC.Core.ViewModels;
using OfflineFirstPOC.Core.Views;
using Xamarin.Forms;

namespace OfflineFirstPOC.Core
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage(new MainViewModel()));
        }
    }
}
