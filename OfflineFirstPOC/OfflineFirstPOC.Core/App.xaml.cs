using OfflineFirstPOC.Core.ViewModels;
using OfflineFirstPOC.Core.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace OfflineFirstPOC.Core
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

            MainPage = new NavigationPage(new MainPage(new MainViewModel()));
        }

        private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if(e.NetworkAccess == NetworkAccess.Internet)
            {
                RunSync(); 
            }
        }

        private void RunSync()
        {
            System.Console.WriteLine("hola!!!"); 
        }
    }
}
