using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Poputkee.Desktop.ViewModels;
using Poputkee.Desktop.Views;
using Poputkee.Infrastructure.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Poputkee;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{

    private readonly ServiceProvider _serviceProvider;

    public App()
    {

        var services = new ServiceCollection();
        ConfigureServices(services);
        _serviceProvider = services.BuildServiceProvider();

        // Конструктор вызывается при запуске приложения
        Debug.WriteLine("\n<-------------------------------------------->\n" +
            "             Конструктор App вызван" +
            "\n<-------------------------------------------->\n");
        //contentControl.Content = new BookRideView();
    }


    private void ConfigureServices(IServiceCollection services)
    {
        // Настройка контекста БД
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql("Host=localhost;Database=poputkee;Username=postgres;Password=1234"));
        services.AddScoped<IUserService, UserService>();
        // Регистрация Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Регистрация ViewModels и окон
        //services.AddTransient<MainWindowViewModel>();
        services.AddSingleton<MainWindow>();
    }


    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Debug.WriteLine("\n<-------------------------------------------->\n" + 
            "App.xaml загружен, стартовое окно открывается" +
            "\n<-------------------------------------------->\n");

    }
}

