using Poputkee.Core.Models;
using Poputkee.Core.Interfaces;
using Poputkee.Desktop.ViewModels;
using System;

namespace Poputkee.Desktop.ViewModels
{
    public class BookRideViewModel : BaseViewModel
    {
        private string _from;
        private string _to;
        private DateTime _selectedDate;

        public string From
        {
            get { return _from; }
            set { SetProperty(ref _from, value); }
        }

        public string To
        {
            get { return _to; }
            set { SetProperty(ref _to, value); }
        }

        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set { SetProperty(ref _selectedDate, value); }
        }

        // Команда для обработки нажатия кнопки "Найти поездки"
        public DelegateCommand FindRidesCommand { get; private set; }

        public BookRideViewModel()
        {
            SelectedDate = DateTime.Now;
            FindRidesCommand = new DelegateCommand(ExecuteFindRides);
        }

        private void ExecuteFindRides()
        {
            // Логика для поиска поездок
        }
    }
}
