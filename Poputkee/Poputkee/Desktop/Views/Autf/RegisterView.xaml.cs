// Poputkee.Desktop/Views/Auth/RegisterView.xaml.cs
using Poputkee.Desktop.ViewModels.Auth;
using System.Windows;
using System.Windows.Controls;

namespace Poputkee.Desktop.Views.Auth
{
    public partial class RegisterView : UserControl
    {
        public RegisterView()
        {
            InitializeComponent();
            Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegisterViewModel viewModel)
            {
                PasswordBox.PasswordChanged += (s, args) =>
                {
                    viewModel.Password = PasswordBox.Password;
                };

                ConfirmPasswordBox.PasswordChanged += (s, args) =>
                {
                    viewModel.ConfirmPassword = ConfirmPasswordBox.Password;
                };
            }
        }
    }
}