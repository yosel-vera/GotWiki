using GotWiki.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace GotWiki.ViewModels
{
    public class ListViewModel<T> : BaseViewModel 
    {
        private ObservableRangeCollection<T> entities;
        private int _currentPage;
        private bool _canLoadMore;
        private string _entityName => $"{typeof(T).Name}s";

        public ObservableRangeCollection<T> Entities
        {
            get { return entities; }
            set
            {
                entities = value;
                OnPropertyChanged(nameof(Entities));
            }
        }

        public ListViewModel(IDataStore dataStore, INavigationService navigationService)
            : base(dataStore, navigationService)
        {
            Title = _entityName;
            entities = new ObservableRangeCollection<T>();
            _canLoadMore = true;
            _currentPage = 1;
        }

        public override async Task InitializeAsync(object parameter)
        {
            await LoadDataAsync();
            await base.InitializeAsync(parameter);
        }

        protected async virtual Task LoadDataAsync()
        {
            IsBusy = true;
            var data = await _dataStore.GetItemsAsync<T>(_entityName, _currentPage);
            if (data.Count() > 0)
            {
                _currentPage++;
                Entities.AddRange(data);
            }
            else
                _canLoadMore = false;
            IsBusy = false;
        }

        public ICommand ItemAppearingCommand => new Command<T>(async (item) => await OnAppearingCommand(item));

        protected async virtual Task OnAppearingCommand(T item)
        {
            var index = Entities.IndexOf(item);
            if (Entities.Count - 2 == index && _canLoadMore)
            {
                await LoadDataAsync();
            }
        }

        public ICommand SelectItemCommand => new Command<T>(async (item) => await OnSelectItemCommand(item));

        protected virtual Task OnSelectItemCommand(T item)
        {
            var viewModelName = item.GetType().FullName.Replace("Model", "ViewModel");
            viewModelName += "DetailsViewModel";
            var entityAssembly = item.GetType().GetTypeInfo().Assembly.FullName;
            var viewModelAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewModelName, entityAssembly);
            var viewModelType = Type.GetType(viewModelAssemblyName);
            return _navigationService.NavigateToAsync(viewModelType, item);
        }
    }
}
