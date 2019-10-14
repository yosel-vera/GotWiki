using GotWiki.Helpers;
using GotWiki.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GotWiki.Models;
using System.Windows.Input;
using Xamarin.Forms;
using MvvmHelpers;

namespace GotWiki.ViewModels
{
    public class BooksViewModel : ListViewModel<Book>
    {
        public BooksViewModel(INavigationService navigationService, IDataStore dataStore)
            : base(dataStore, navigationService)
        {
        }

        public override Task InitializeAsync(object parameter)
        {
            return base.InitializeAsync(parameter);
        }
      
    }
}
