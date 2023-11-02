using Microsoft.Extensions.DependencyInjection;
using P05WPF.Services;
using P05WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace P05WPF //To jest tak samo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();

        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IMyApiService, MyApiService>();
            services.AddSingleton<ShoeViewModel>();
            //services.AddSingleton<CityViewModel>();
            //services.AddSingleton<WeatherViewModel>();
            //services.AddSingleton<RegionViewModel>();
            //services.AddSingleton<NeighbourViewModel>();
            //services.AddSingleton<HourViewModel>();
            //services.AddSingleton<YesterdayViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddTransient<MainWindow>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
