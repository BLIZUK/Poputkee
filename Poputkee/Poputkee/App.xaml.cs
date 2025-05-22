using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Poputkee.Desktop.ViewModels.MainMenu;
using Poputkee.Desktop.Views.MainMenu;
using Poputkee.Core.Services;
//using Poputkee.Infrastructure.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using Poputkee.Core.Services;
using System.Net.NetworkInformation;


namespace Poputkee
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        // private readonly ServiceProvider _serviceProvider;
        private IServiceProvider _serviceProvider;


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            //--------------------------------------------------------------------------->
            //services.AddSingleton<ITripService, TripService>();
            // Используем мок-сервис вместо реального TripService
            services.AddSingleton<ITripService, MockTripService>(); // <- Здесь изменение
            //
            //--------------------------------------------------------------------------->

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<BookRideViewModel>();
            services.AddTransient<CreateRideViewModel>();
            services.AddTransient<ArchiveViewModel>();

            _serviceProvider = services.BuildServiceProvider();

            MainWindow = new MainWindow
            {
                DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>()
            };

            //MainWindow.Show();

        }


        //public App()
        //{

        //    var services = new ServiceCollection();
        //    //ConfigureServices(services);
        //    //_serviceProvider = services.BuildServiceProvider();

        //    // Конструктор вызывается при запуске приложения
        //    Debug.WriteLine("\n<-------------------------------------------->\n" +
        //        "             Конструктор App вызван" +
        //        "\n<-------------------------------------------->\n");
        //}
    }
}

