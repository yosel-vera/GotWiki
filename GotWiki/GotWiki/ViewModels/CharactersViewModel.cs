using GotWiki.Models;
using GotWiki.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GotWiki.ViewModels
{
    public class CharactersViewModel : ListViewModel<Character>
    {
        public CharactersViewModel(IDataStore dataStore, INavigationService navigationService)
            : base(dataStore, navigationService)
        { 
        }
    }
}
