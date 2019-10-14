using GotWiki.Models;
using GotWiki.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GotWiki.ViewModels
{
    public class BookDetailsViewModel : BaseViewModel
    {
        private Book _book;
        public Book Book 
        {
            get { return _book; }
            set
            {
                _book = value;
                OnPropertyChanged(nameof(Book));
            }
        }
        public BookDetailsViewModel(IDataStore dataStore, INavigationService navigationService)
            : base(dataStore, navigationService)
        { 
        }

        public override Task InitializeAsync(object parameter)
        {
            Book = (Book)parameter ?? throw new ArgumentNullException();
            Title = Book.Name;
            return base.InitializeAsync(parameter);
        }
    }
}
