using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.MainMenu
{

    public class MainWindowViewModel : BaseViewModel
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
            //// Инициализация: сразу показываем BookRideView
            //CurrentView = new BookRideViewModel();

            //Debug.WriteLine("--->>> Запуск основного окна");

            ShowBookRideCommand = new RelayCommand(_ => CurrentView = new BookRideViewModel());
            ShowCreateRideCommand = new RelayCommand(_ => CurrentView = new CreateRideViewModel());
        }


        // Команды для навигации
        public ICommand ShowBookRideCommand { get; }
        public ICommand ShowCreateRideCommand { get; }


        //// INotifyPropertyChanged реализация
        //public event PropertyChangedEventHandler? PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}