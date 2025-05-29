// System namespaces
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Net.NetworkInformation;

// Third-party dependencies
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

// Application components
using Poputkee.Core.Services;
using Poputkee.Desktop.ViewModels.MainMenu;
using Poputkee.Desktop.Views.MainMenu;
using Poputkee.Core.Interfaces;
using Poputkee.Desktop.ViewModels;

namespace Poputkee
{
    /// <summary>
    /// Главный класс приложения, отвечающий за конфигурацию и запуск
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        public static IServiceProvider ServiceProvider { get; private set; }

        // Провайдер служб для Dependency Injection
        private IServiceProvider _serviceProvider;

        #endregion

        #region Application Lifecycle

        /// <summary>
        /// Метод инициализации приложения
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            ConfigureServices();
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            Debug.WriteLine("Application startup completed");
        }

        #endregion


        #region Configuration Methods

        /// <summary>
        /// Конфигурация системы Dependency Injection
        /// </summary>
        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            // Регистрация сервисов
            services.AddSingleton<ITripService, MockTripService>();
            services.AddSingleton<IAccountService, MockAccountService>();
            services.AddSingleton<INavigationService, NavigationService>();

            // Регистрация ViewModels
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<BookRideViewModel>();
            services.AddTransient<CreateRideViewModel>();
            services.AddTransient<ArchiveViewModel>();
            services.AddTransient<AccountViewModel>();
            services.AddTransient<EditAccountViewModel>();

            // Регистрация MainWindow
            services.AddSingleton<MainWindow>();

            _serviceProvider = services.BuildServiceProvider();
            ServiceProvider = _serviceProvider;
        }

        #endregion
    }
}