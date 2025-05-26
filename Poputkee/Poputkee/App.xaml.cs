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
using Poputkee.Desktop.ViewModels;
using Poputkee.Desktop.ViewModels.MainMenu;
using Poputkee.Desktop.Views.MainMenu;
using Poputkee.Core.Interfaces;

namespace Poputkee
{
    /// <summary>
    /// Главный класс приложения, отвечающий за конфигурацию и запуск
    /// </summary>
    public partial class App : Application
    {
        #region Fields

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
            ConfigureApplicationSettings();
            ConfigureServices();
            InitializeMainWindow();

            Debug.WriteLine("Application startup completed");
        }

        #endregion


        #region Configuration Methods

        /// <summary>
        /// Настройка параметров приложения
        /// </summary>
        private void ConfigureApplicationSettings()
        {
            ShutdownMode = ShutdownMode.OnLastWindowClose;
        }

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
            //services.AddTransient<EditAccountViewModel>();

            _serviceProvider = services.BuildServiceProvider();
        }

        #endregion


        #region Window Initialization

        /// <summary>
        /// Инициализация главного окна приложения
        /// </summary>
        private void InitializeMainWindow()
        {
            if (MainWindow == null)
            {
                CreateAndShowMainWindow();
            }
        }

        /// <summary>
        /// Создание и отображение главного окна
        /// </summary>
        private void CreateAndShowMainWindow()
        {
            MainWindow = new MainWindow
            {
                DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>()
            };

            MainWindow.Show();
        }

        #endregion
    }
}