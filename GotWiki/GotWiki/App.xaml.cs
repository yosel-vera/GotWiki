using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using Xamarin.Forms;
using System.IO;
using Xamarin.Essentials;
using GotWiki.Views;
using GotWiki.Services;

namespace GotWiki
{
    public partial class App : Application
    {
        public const string BackendUrl = "https://www.anapioficeandfire.com/api";
        public static IServiceProvider ServiceProvider { get; set; }

        private INavigationService _nagivationService;

        public App()
        {
            InitializeComponent();
            _nagivationService = ServiceProvider.GetService<INavigationService>();
            _nagivationService.InitializeAsync();
            //MainPage =  new NavigationPage(ServiceProvider.GetService<MainPageView>());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
