// Poputkee.Desktop/Views/Auth/LoginView.xaml.cs
using Poputkee.Desktop.ViewModels.Auth;
using System.Windows;
using System.Windows.Controls;

namespace Poputkee.Desktop.Views.Auth
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                PasswordBox.PasswordChanged += (s, args) =>
                {
                    viewModel.Password = PasswordBox.Password;
                };
            }
        }
    }
}