using GotWiki.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GotWiki.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        public TestViewModel(IDataStore dataStore, INavigationService navigationService) 
            : base(dataStore, navigationService)
        {
            Title = "Test Title";
        }
    }
}
