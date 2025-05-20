    using Poputkee.Desktop.ViewModels;
    using Poputkee.Core.Services;
    using System.Windows.Input;
    using System.Windows;
    using System.Diagnostics;
using System.Windows.Controls;


namespace Poputkee.Desktop.ViewModels.MainMenu
{
    public class BookRideViewModel : BaseViewModel
    {
        //  Поля
        // Команда поиска поездок
        public ICommand SearchRidesCommand { get; }
        //  Свойства с авто-обновлением
        private string _from = "Откуда";
        private string _to = "Куда то))";
        private DateTime _selectedDate = DateTime.Now;
        private int _neededSeats;


        // Конструкторк
        public BookRideViewModel()
        {
            Logger.LogDebug("--->>> Конструктор BookRideViewModel вызван");
            SearchRidesCommand = new RelayCommand(SearchRides);
        }

        
        public string From
        {
            get => _from;
            set => SetProperty(ref _from, value);
        }


        public string To
        {
            get => _to;
            set => SetProperty(ref _to, value);
        }

        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }


        public int NeededSeats
        {
            get => _neededSeats;
            set => SetProperty(ref _neededSeats, value);
        }


        // Обработка кнопки
        private void SearchRides(object parameter)
        {
            Debug.WriteLine("--->>>! date:", SelectedDate);
        }
    }
}