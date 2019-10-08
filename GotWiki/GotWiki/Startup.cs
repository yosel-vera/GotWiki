using GotWiki.Services;
using GotWiki;
using GotWiki.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xamarin.Essentials;
using GotWiki.ViewModels;
using GotWiki.Helpers;
namespace GotWiki
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }
        public static App Init()
        {
            var systemDir = FileSystem.CacheDirectory;
            Utils.ExtractSaveResource("GotWiki.appsettings.json", systemDir);
            var fullConfig = Path.Combine(systemDir, "GotWiki.appsettings.json");

            var host = new HostBuilder()
                .ConfigureHostConfiguration(c =>
                {
                    // Tell the host configuration where to file the file (this is required for Xamarin apps)
                    c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });

                    //read in the configuration file!
                    c.AddJsonFile(fullConfig);
                })
                .ConfigureServices((c, x) =>
                {
                    // Configure our local services and access the host configuration
                    ConfigureServices(c, x);
                })
                .ConfigureLogging(l => l.AddConsole(o =>
                {
                            //setup a console logger and disable colors since they don't have any colors in VS
                            o.DisableColors = true;
                }))
                .Build();

            //Save our service provider so we can use it later.
            App.ServiceProvider = host.Services;
            return App.ServiceProvider.GetService<App>();
        }

        static void ConfigureServices(HostBuilderContext ctx, IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<MainPageView>();
            services.AddTransient<MainPageViewModel>();
            services.AddSingleton<App>();
            services.AddTransient<BooksViewModel>();
            services.AddTransient<HousesViewModel>();

            services.AddTransient<BooksView>();
            services.AddTransient<HousesView>();

            services.AddTransient<IDataStore,DataStore>();
            services.AddSingleton<INavigationService, NavigationService>();

        }

    }
}
