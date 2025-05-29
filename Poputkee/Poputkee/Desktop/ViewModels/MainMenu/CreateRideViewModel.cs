// System namespaces
using System;
using System.Diagnostics;
using System.Windows.Input;

// Application components
using Poputkee.Core.Models;
using Poputkee.Desktop.ViewModels.MainMenu;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    /// <summary>
    /// ViewModel для создания новой поездки
    /// </summary>
    public class CreateRideViewModel : BaseViewModel
    {
        #region Fields

        public Trip Trip { get; set; } = new Trip();

        private string _fromCity = "Откуда";
        private string _toCity = "Куда";
        private string _departureTime = "Выберите время";
        private int _availableSeats = 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор инициализирующий команды и логирующий создание экземпляра
        /// </summary>
        public CreateRideViewModel()
        {
            Debug.WriteLine("--->>> Инициализация CreateRideViewModel");
            InitializeCommands();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Город отправления
        /// </summary>
        public string FromCity
        {
            get => _fromCity;
            set => SetProperty(ref _fromCity, value);
        }

        /// <summary>
        /// Город назначения
        /// </summary>
        public string ToCity
        {
            get => _toCity;
            set => SetProperty(ref _toCity, value);
        }

        /// <summary>
        /// Время отправления (строковое представление)
        /// </summary>
        /// <remarks>
        /// TODO: Рассмотреть возможность использования типа DateTime
        /// </remarks>
        public string DepartureTime
        {
            get => _departureTime;
            set => SetProperty(ref _departureTime, value);
        }

        /// <summary>
        /// Количество доступных мест
        /// </summary>
        public int AvailableSeats
        {
            get => _availableSeats;
            set => SetProperty(ref _availableSeats, value);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Команда для создания новой поездки
        /// </summary>
        public ICommand CreateRideCommand { get; private set; }

        #endregion

        #region Command Implementation

        /// <summary>
        /// Инициализация команд
        /// </summary>
        private void InitializeCommands()
        {
            CreateRideCommand = new RelayCommand(ExecuteCreateRide);
        }

        /// <summary>
        /// Обработчик создания поездки
        /// </summary>
        private void ExecuteCreateRide(object parameter)
        {
            Debug.WriteLine("---->>> Запрос на создание поездки:");
            
            LogRideDetails();

            // TODO: Добавить логику сохранения поездки
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Логирование деталей поездки
        /// </summary>
        private void LogRideDetails()
        {
            Debug.WriteLine(
                $"--------------------------------------\n" +
                $"From: {FromCity}\n" +
                $"To: {ToCity}\n" +
                $"Time: {DepartureTime}\n" +
                $"Seats: {AvailableSeats}\n" +
                $"--------------------------------------");
        }

        #endregion
    }
}