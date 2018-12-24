using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SwipeCardViewExample.Forms.UI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormsApp : Application
    {
        public static double ScreenHeight;
        public static double ScreenWidth;

        public FormsApp()
        {
            InitializeComponent();
        }
    }
}
