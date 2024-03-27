using CommunityToolkit.Mvvm.ComponentModel;
using SR.Prosegur.Services;
using SR.Prosegur.Services.UserService;
using SR.Prosegur.ViewModels.Base;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using SR.Prosegur.Extensions;
using SR.Prosegur.Models;
using CommunityToolkit.Mvvm.Input;
using Acr.UserDialogs;

namespace SR.Prosegur.ViewModels
{
    public partial class SubscriptionListViewModel : ViewModelBase
    {
        IUserService _userService;
        public SubscriptionListViewModel(INavigationService _navigationService, IUserService userService) : base(_navigationService)
        {
            _userService = userService;
        }

        [ObservableProperty]
        private ObservableCollection<UserModel> _userList;

        [ObservableProperty]
        private int _activeCount;

        [ObservableProperty]
        private int _totalCount;

        [ObservableProperty]
        private bool _isRefreshing;

        [RelayCommand]
        public async Task ItemSelected(object item)
        {
            if (item is UserModel a)
            {
                await _navigationService.NavigateToAsync<UserDetailViewModel>(a);
            }
        }

        [RelayCommand]
        public async Task Refresh()
        {
            IsBusy = true;
            var response = await _userService.GetUsers();
            UserList = response.ToObservableCollection();

            TotalCount = UserList.Count;
            ActiveCount = UserList.Count(s => s.Subscription.Status == "Active");
            IsBusy = false;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
            await Refresh();
        }
    }
}
