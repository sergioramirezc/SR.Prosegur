using SR.Prosegur.Services.UserService;
using SR.Prosegur.Services;
using SR.Prosegur.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using SR.Prosegur.Models;
using System.Threading.Tasks;

namespace SR.Prosegur.ViewModels
{
    public partial class UserDetailViewModel : ViewModelBase
    {
        [ObservableProperty]
        private UserModel _user;
        public UserDetailViewModel(INavigationService _navigationService) : base(_navigationService)
        {
        }

        public override async Task InitializeAsync(object navigationData)
        {
            await base.InitializeAsync(navigationData);
            User = navigationData as UserModel;
        }
    }
}
