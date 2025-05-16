// Poputkee.Desktop/App.xaml.cs
using Microsoft.Extensions.DependencyInjection;
using Poputkee.Core.Interfaces;
using Poputkee.Desktop.Views;
using System.Windows;

public partial class App : Application
{
    private IServiceProvider _serviceProvider;

    public App()
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
        services.AddScoped<IUnitOfWork, DatabaseInitializer>();
        services.AddSingleton<MainWindow>();
        services.AddTransient<MainViewModel>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}