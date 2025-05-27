using Poputkee.Desktop.ViewModels.MainMenu;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;



namespace Poputkee.Desktop.Views.MainMenu
{
    /// <summary>
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {
        public AccountView()
        {
            InitializeComponent();
            //DataContext = App.ServiceProvider.GetRequiredService<AccountViewModel>();
        }
    }
}
