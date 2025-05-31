// Poputkee.Desktop/ViewModels/MainMenu/CreateRideViewModel.cs
using Poputkee.Core.Models;
using Poputkee.Core.Services;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    public class CreateRideViewModel : BaseViewModel
    {
        private readonly ITripService _tripService;
        private string _fromCity;
        private string _toCity;
        private DateTime _departureTime = DateTime.Now.AddHours(1);
        private int _availableSeats = 1;

        public CreateRideViewModel(ITripService tripService)
        {
            _tripService = tripService;
            CreateRideCommand = new RelayCommand(async _ => await CreateRideAsync());
        }

        public ICommand CreateRideCommand { get; }

        public string FromCity
        {
            get => _fromCity;
            set => SetProperty(ref _fromCity, value);
        }

        public string ToCity
        {
            get => _toCity;
            set => SetProperty(ref _toCity, value);
        }

        public DateTime DepartureTime
        {
            get => _departureTime;
            set => SetProperty(ref _departureTime, value);
        }

        public int AvailableSeats
        {
            get => _availableSeats;
            set => SetProperty(ref _availableSeats, value);
        }

        private async Task CreateRideAsync()
        {
            if (!ValidateInput()) return;

            try
            {
                var newTrip = new Trip
                {
                    FromCity = FromCity,
                    ToCity = ToCity,
                    DepartureTime = DepartureTime,
                    AvailableSeats = AvailableSeats
                };

                await _tripService.CreateTripAsync(newTrip);
                MessageBox.Show("Поездка успешно создана!", "Успех",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                ResetForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании поездки: {ex.Message}",
                    "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(FromCity))
            {
                MessageBox.Show("Введите город отправления", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(ToCity))
            {
                MessageBox.Show("Введите город назначения", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (DepartureTime < DateTime.Now)
            {
                MessageBox.Show("Дата отправления не может быть в прошлом", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (AvailableSeats < 1 || AvailableSeats > 10)
            {
                MessageBox.Show("Количество мест должно быть от 1 до 10", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            FromCity = string.Empty;
            ToCity = string.Empty;
            DepartureTime = DateTime.Now.AddHours(1);
            AvailableSeats = 1;
        }
    }
}