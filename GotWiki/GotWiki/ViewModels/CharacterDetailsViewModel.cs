using GotWiki.Models;
using GotWiki.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GotWiki.ViewModels
{
    public class CharacterDetailsViewModel : BaseViewModel
    {
        private Character character;

        public Character Character
        {
            get { return character; }
            set 
            {
                character = value;
                OnPropertyChanged(nameof(Character));
            }
        }
        public CharacterDetailsViewModel(IDataStore dataStore, INavigationService navigationService)
            : base(dataStore, navigationService)
        { 
        }

        public override Task InitializeAsync(object parameter)
        {
            Character = (Character)parameter ?? throw new ArgumentNullException();
            return base.InitializeAsync(parameter);
        }
    }
}

