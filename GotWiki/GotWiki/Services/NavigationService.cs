using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GotWiki.ViewModels;
using Xamarin.Forms;

namespace GotWiki.Services
{
    public class NavigationService : INavigationService
    {
        public BaseViewModel PreviousPageViewModel => throw new NotImplementedException();

        public Task InitializeAsync()
        {
            return NavigateToAsync<MainPageViewModel>();
        }

        public Task NavigateToAsync(Type viewModelType, object parameter = null)
        {
            return InternalNavigateToAsync(viewModelType, parameter);
        }

        public Task NavigateToAsync<TViewModel>(object parameter = null) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task RemoveBackStackAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveLastFromBackStackAsync()
        {
            throw new NotImplementedException();
        }

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType);
            //todo add init navigation here
            var navigationPage = Application.Current.MainPage as NavigationPage;
            if (navigationPage != null)
                await navigationPage.PushAsync(page);
            else
                Application.Current.MainPage = new NavigationPage(page);
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);

        }


        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private Page CreatePage(Type viewModelType)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
                throw new Exception($"Cannot locate page type for {viewModelType}");
            Page page = (Page)App.ServiceProvider.GetService(pageType);
            return page;
        }

    }
}
