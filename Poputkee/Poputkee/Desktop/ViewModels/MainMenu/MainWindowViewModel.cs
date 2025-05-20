using Poputkee.Core.Services;
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
            // Используем мок-сервис для тестов
            ITripService tripService = new TripService();

            ShowArchiveCommand = new RelayCommand(_ =>
                CurrentView = new ArchiveViewModel(tripService));
        }


        // Команды для навигации
        public ICommand ShowBookRideCommand { get; }
        public ICommand ShowCreateRideCommand { get; }

        public ICommand ShowArchiveCommand { get; }


        //// INotifyPropertyChanged реализация
        //public event PropertyChangedEventHandler? PropertyChanged;
        //protected virtual void OnPropertyChanged(string propertyName)
        //    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}