using Android.Content;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using KittenView.Core.Plugins;
using KittenView.Droid.Plugins;

namespace KittenView.Droid
{
    public class Setup : MvxAndroidSetup
    {
        private readonly Context _applicationContext;

        public Setup(Context applicationContext) : base(applicationContext)
        {
            _applicationContext = applicationContext;
        }

        protected override IMvxApplication CreateApp()
        {
            return new KittenView.Core.App();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.RegisterSingleton<IToastPlugin>(new ToastPlugin(_applicationContext));
            base.InitializeFirstChance();
        }
    }
}