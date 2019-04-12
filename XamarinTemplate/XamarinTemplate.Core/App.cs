using MvvmCross.ViewModels;
using XamarinTemplate.Core.ViewModels;

namespace XamarinTemplate.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            RegisterAppStart<MvxMainViewModel>();
        }
    }
}
