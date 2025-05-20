using Poputkee.Core.Models;
using Poputkee.Desktop.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels
{
    public class CreateRideViewModel : INotifyPropertyChanged
    {
        //private readonly IUnitOfWork _unitOfWork;


        // Конструктор
        public CreateRideViewModel()
        {
            ShowCreateRideCommand = new RelayCommand(ExecuteSearch);
        }


        // Команда создания поездки
        public ICommand ShowCreateRideCommand { get; }


        private void ExecuteSearch(object parameter)
        {
            // Логика поиска поездок
        }


        // Свойства для привязки
        public string FromCity { get; set; }
        public string ToCity { get; set; }
        public DateTime? DepartureDate { get; set; } = DateTime.Now;
        public string DepartureTime { get; set; }
        public int AvailableSeats { get; set; }


        // Проверка валидности данных
        private bool CanCreateRide()
        {
            return !string.IsNullOrEmpty(FromCity)
                && !string.IsNullOrEmpty(ToCity)
                && DepartureDate != null
                && TimeSpan.TryParse(DepartureTime, out _)
                && AvailableSeats > 0;
        }


        // INotifyPropertyChanged реализация
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        // Очистка формы
        private void ClearForm()
        {
            FromCity = "";
            ToCity = "";
            DepartureDate = DateTime.Now;
            DepartureTime = "";
            AvailableSeats = 0;
        }
    }
}