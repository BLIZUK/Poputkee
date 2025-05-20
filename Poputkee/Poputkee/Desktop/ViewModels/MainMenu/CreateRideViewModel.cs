using Poputkee.Core.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    public class CreateRideViewModel : BaseViewModel
    {

        // Конструктор
        public CreateRideViewModel()
        {
            Debug.WriteLine("--->>> Запуск CreateRideViewModel конструктора");
            CreateRideCommand = new RelayCommand(ExecuteSearch);
        }


        // Кнопка/Команда создания поездки
        public ICommand CreateRideCommand { get; }


        private void ExecuteSearch(object parameter)
        {
            // Логика поиска поездок
            Debug.WriteLine("---->>>! Кнопка создания поездки:");
            Debug.WriteLine($"--------------------------------------\n" +
                $"FromCity = {FromCity} " +
                $"\nToCity = {ToCity}" +
                $"\nDepartureTime = {DepartureTime}" +
                $"\nAvailableSeats = {AvailableSeats}" +
                $"\n--------------------------------------\n");
        }


        // Свойства для привязки

        private string _fromCity;
        public string FromCity
        {
            get => _fromCity;
            set => SetProperty(ref _fromCity, value);
        }

        private string _toCity;
        public string ToCity
        {
            get => _toCity;
            set => SetProperty(ref _toCity, value);
        }

        private string _departureTime;
        public string DepartureTime
        {
            get => _departureTime;
            set => SetProperty(ref _departureTime, value);
        }

        private int _availableSeats;
        public int AvailableSeats
        {
            get => _availableSeats;
            set => SetProperty(ref _availableSeats, value);
        }
    }
}