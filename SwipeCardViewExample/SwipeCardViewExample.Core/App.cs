using MvvmCross.ViewModels;
using SwipeCardViewExample.Core.ViewModels;

namespace SwipeCardViewExample.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            RegisterAppStart<TinderViewModel>();
        }
    }
}
