using Microsoft.Extensions.DependencyInjection;
using Poputkee.Desktop.ViewModels.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Poputkee.Desktop.Views.MainMenu
{
    /// <summary>
    /// Логика взаимодействия для EditAccountView.xaml
    /// </summary>
    public partial class EditAccountView : UserControl
    {
        public EditAccountView()
        {
            InitializeComponent();
            //DataContext = App.ServiceProvider.GetRequiredService<EditAccountViewModel>();   // ОШИБКА!
                                                                                            /*
                                                                                             * В EditAccountView.xaml.cs вы принудительно задаете DataContext:
                                                                                             * Это ломает связь через DataTemplate, так как WPF ожидает, что DataContext будет
                                                                                             * устанавливаться автоматически через привязку к CurrentView в MainWindowViewModel.
                                                                                             */
        }
    }
}
