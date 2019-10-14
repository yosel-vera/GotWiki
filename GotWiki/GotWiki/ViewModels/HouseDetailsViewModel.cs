using GotWiki.Models;
using GotWiki.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GotWiki.ViewModels
{
    public class HouseDetailsViewModel : BaseViewModel
    {
        private House house;
        public House House 
        {
            get
            {
                return house;
            }
            set
            {
                house = value;
                OnPropertyChanged(nameof(House));
            }
        }

        public HouseDetailsViewModel(IDataStore dataStore, INavigationService navigationService)
            :base(dataStore , navigationService)
        {
            
        }

        public override Task InitializeAsync(object parameter)
        {
            House = (House)parameter ?? throw new ArgumentNullException();
            Title = House.Name;
            return base.InitializeAsync(parameter);
        }
    }
}
