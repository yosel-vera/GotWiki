using GotWiki.Models;
using GotWiki.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GotWiki.ViewModels
{
    public class HousesViewModel : ListViewModel<Houses>
    {
        public HousesViewModel(INavigationService navigationService, IDataStore dataStore)
            : base(dataStore, navigationService)
        {
        }

        public override Task InitializeAsync(object parameter)
        {
            return base.InitializeAsync(parameter);
        }
    }
}
