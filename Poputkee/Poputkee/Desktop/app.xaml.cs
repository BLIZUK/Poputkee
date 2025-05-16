using Microsoft.Extensions.DependencyInjection;
using Poputkee.Desktop.ViewModels;
using Poputkee.Desktop.Views;
using System.Windows;

namespace Poputkee.Desktop
{
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            // Конфигурация сервисов
            var services = new ServiceCollection();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Регистрация ViewModels
            services.AddTransient<MainWindowViewModel>();

            // Регистрация главного окна
            services.AddSingleton<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Создаем главное окно через DI-контейнер
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.DataContext = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            mainWindow.Show();
        }
    }
}