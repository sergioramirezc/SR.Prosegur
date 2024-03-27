using SR.Prosegur.Services;
using SR.Prosegur.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SR.Prosegur
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            InitApp();
        }

        private void InitApp()
        {
            ViewModelLocator.RegisterDependencies();
        }

        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart()
        {
            base.OnStart();
            await InitNavigation();
        }
    }
}
