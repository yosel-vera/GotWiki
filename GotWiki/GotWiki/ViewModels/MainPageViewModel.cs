using GotWiki.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace GotWiki.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ICommand NavigateCommand => new Command<string>(async (resource) => await NavigateAsync(resource));

        public MainPageViewModel(IDataStore dataStore, INavigationService  navigationService) 
            : base(dataStore, navigationService)
        {
        }

        private Task NavigateAsync(string resource)
        {
            return _navigationService.NavigateToAsync<ResourceListViewModel>(resource);
        }


    }
}