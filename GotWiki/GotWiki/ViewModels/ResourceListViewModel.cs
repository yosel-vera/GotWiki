using GotWiki.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GotWiki.ViewModels
{
    public class ResourceListViewModel : BaseViewModel
    {
        public ResourceListViewModel(INavigationService navigationService, IDataStore dataStore)
            : base(dataStore, navigationService)
        { 
        }

        public override Task InitializeAsync(object parameter)
        {
            Title = parameter.ToString();
            return base.InitializeAsync(parameter);
        }
    }
}
