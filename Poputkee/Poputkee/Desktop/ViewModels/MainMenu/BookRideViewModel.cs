// System namespaces
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

// Application components
using Poputkee.Core.Services;
using Poputkee.Desktop.ViewModels;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    /// <summary>
    /// ViewModel для поиска и бронирования поездок
    /// </summary>
    public class BookRideViewModel : BaseViewModel
    {
        #region Fields

        private string _from = "Откуда";
        private string _to = "Куда то))";
        private DateTime _selectedDate = DateTime.Now;
        private int _neededSeats;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор инициализирующий команды и логирующий создание экземпляра
        /// </summary>
        public BookRideViewModel()
        {
            Logger.LogDebug("--->>> Конструктор BookRideViewModel вызван");
            InitializeCommands();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Пункт отправления
        /// </summary>
        public string From
        {
            get => _from;
            set => SetProperty(ref _from, value);
        }

        /// <summary>
        /// Пункт назначения
        /// </summary>
        public string To
        {
            get => _to;
            set => SetProperty(ref _to, value);
        }

        /// <summary>
        /// Выбранная дата поездки
        /// </summary>
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set => SetProperty(ref _selectedDate, value);
        }

        /// <summary>
        /// Требуемое количество мест
        /// </summary>
        public int NeededSeats
        {
            get => _neededSeats;
            set => SetProperty(ref _neededSeats, value);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Команда для поиска доступных поездок
        /// </summary>
        public ICommand SearchRidesCommand { get; private set; }

        #endregion

        #region Initialization

        /// <summary>
        /// Инициализация команд
        /// </summary>
        private void InitializeCommands()
        {
            SearchRidesCommand = new RelayCommand(SearchRides);
        }

        #endregion

        #region Command Handlers

        /// <summary>
        /// Обработчик поиска поездок
        /// </summary>
        private void SearchRides(object parameter)
        {
            Debug.WriteLine($"--->>> Дата поиска: {SelectedDate:yyyy-MM-dd HH:mm}");
            // TODO: Реализовать логику поиска поездок
        }

        #endregion
    }
}