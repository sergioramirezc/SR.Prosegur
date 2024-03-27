using CommunityToolkit.Mvvm.ComponentModel;
using SR.Prosegur.Services;
using System.Threading.Tasks;

namespace SR.Prosegur.ViewModels.Base
{
    public abstract partial class ViewModelBase : ObservableObject
    {
        protected readonly INavigationService _navigationService;

        [ObservableProperty]
        private bool _isBusy;

        public ViewModelBase(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        public virtual async Task InitializeAsync(object navigationData)
        {
        }
    }
}