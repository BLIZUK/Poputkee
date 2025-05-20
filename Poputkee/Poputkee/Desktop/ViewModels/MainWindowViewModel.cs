using Poputkee.Desktop.ViewModels;
using System.ComponentModel;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }


        public MainWindowViewModel()
        {
            ShowBookRideCommand = new RelayCommand(_ => CurrentView = new BookRideViewModel());
            ShowCreateRideCommand = new RelayCommand(_ => CurrentView = new CreateRideViewModel());
        }


        // Команды для навигации
        public ICommand ShowBookRideCommand { get; }
        public ICommand ShowCreateRideCommand { get; }


        // INotifyPropertyChanged реализация
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}