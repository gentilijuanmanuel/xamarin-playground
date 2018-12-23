using MvvmCross.Forms.Views;
using SwipeCardViewExample.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace SwipeCardViewExample.Forms.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TinderView : MvxContentPage<TinderViewModel>
    {
        public TinderView()
        {
            InitializeComponent();
        }
    }
}
