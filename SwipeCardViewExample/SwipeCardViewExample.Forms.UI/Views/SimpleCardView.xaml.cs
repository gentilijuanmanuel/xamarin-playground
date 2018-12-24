using MvvmCross.Forms.Views;
using SwipeCardViewExample.Core.Parameters;
using SwipeCardViewExample.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace SwipeCardViewExample.Forms.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimpleCardView : MvxContentPage<SimpleCardViewModel>
    {
        public SimpleCardView()
        {
            InitializeComponent();
        }
    }
}
