using GotWiki.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using GotWiki.Models;
using System;

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
            ResourceType type = (ResourceType)Enum.Parse(typeof(ResourceType), resource);
            switch (type)
            {
                case ResourceType.Books:
                    return _navigationService.NavigateToAsync<BooksViewModel>();
                case ResourceType.Houses:
                    return _navigationService.NavigateToAsync<HousesViewModel>();
                case ResourceType.Characters:
                    return _navigationService.NavigateToAsync<CharactersViewModel>();
                default:
                    return Task.FromResult(true);
            }
        }


    }
}