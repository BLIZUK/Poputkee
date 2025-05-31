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
using Poputkee.Desktop.ViewModels.Auth;
using Poputkee.Desktop.Views.MainMenu;
using Poputkee.Core.Interfaces;
using Poputkee.Infrastructure.Data;

namespace Poputkee
{
    /// <summary>
    /// Главный класс приложения, отвечающий за конфигурацию и запуск
    /// </summary>
    public partial class App : Application
    {
        #region Fields

        public static IServiceProvider ServiceProvider { get; private set; }

        #endregion

        #region Application Lifecycle

        /// <summary>
        /// Метод инициализации приложения
        /// </summary>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShutdownMode = ShutdownMode.OnLastWindowClose;

            // Создаем конфигурацию БД
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite("Data Source=poputkee.db")
                .Options;

            // Создаем контекст БД
            var context = new AppDbContext(options);
            context.Database.EnsureCreated();

            // Конфигурируем сервисы
            ConfigureServices(context);

            // Инициализируем главное окно
            InitializeMainWindow();

            Debug.WriteLine("Application startup completed");
        }

        #endregion

        #region Configuration Methods

        /// <summary>
        /// Конфигурация системы Dependency Injection
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        private void ConfigureServices(AppDbContext context)
        {
            var services = new ServiceCollection();

            // Регистрируем контекст БД
            services.AddSingleton(context);

            // Регистрация сервисов
            services.AddScoped<ITripService, TripService>();
            services.AddScoped<IAuthService, AuthService>(); // Новый сервис
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddSingleton<IAccountService, MockAccountService>();

            // Регистрация ViewModels
            services.AddTransient<LoginViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<BookRideViewModel>();
            services.AddTransient<CreateRideViewModel>();
            services.AddTransient<ArchiveViewModel>();
            services.AddTransient<AccountViewModel>();
            services.AddTransient<EditAccountViewModel>();

            // Регистрация MainWindow
            services.AddSingleton<MainWindow>();

            ServiceProvider = services.BuildServiceProvider();
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
            // Используем ServiceProvider для получения MainWindow
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>();
            MainWindow = mainWindow;
            mainWindow.Show();
        }

        #endregion
    }
}