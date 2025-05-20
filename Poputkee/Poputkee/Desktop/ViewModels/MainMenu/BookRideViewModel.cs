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
        //  Поля со свойства с авто-обновлением
        private DateTime _selectedDate = DateTime.Now;
        private string _From = "Откуда";
        private string _To = "Куда";

        // Кнопка/Команда поиска поездок
        public ICommand SearchRidesCommand { get; }

        public BookRideViewModel()
        {
            Logger.LogDebug("--->>> Конструктор BookRideViewModel вызван");
            SearchRidesCommand = new RelayCommand(SearchRides);
        }

        private void SearchRides(object parameter)
        {
            Debug.WriteLine("--->>>! date:", SelectedDate);
        }


        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        //public string From
        //    {
        //   //get => TextBox.FromCityTextBox
        //    }

    }
    }