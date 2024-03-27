using SR.Prosegur.ViewModels.Base;
using System.Threading.Tasks;

namespace SR.Prosegur.Services
{
    public interface INavigationService
    {
		ViewModelBase PreviousPageViewModel { get; }

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

        Task NavigateBackAsync();

    }
}