// System namespaces
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

// Application components
using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using Poputkee.Core.Services;
using Poputkee.Desktop.ViewModels;

namespace Poputkee.Desktop.ViewModels.MainMenu
{
    /// <summary>
    /// ViewModel для работы с архивом завершенных поездок
    /// </summary>
    public class ArchiveViewModel : BaseViewModel
    {
        #region Fields

        private readonly ITripService _tripService;
        private Trip _selectedTrip;

        #endregion


        #region Constructors

        /// <summary>
        /// Конструктор с внедрением зависимости сервиса поездок
        /// </summary>
        /// <param name="tripService">Сервис для работы с поездками</param>
        public ArchiveViewModel(ITripService tripService)
        {
            _tripService = tripService;
            InitializeCommands();
            LoadCompletedTrips();
        }

        #endregion


        #region Properties

        /// <summary>
        /// Коллекция завершенных поездок
        /// </summary>
        public ObservableCollection<Trip> CompletedTrips { get; } = new ObservableCollection<Trip>();

        /// <summary>
        /// Выбранная поездка в архиве
        /// </summary>
        public Trip SelectedTrip
        {
            get => _selectedTrip;
            set => SetProperty(ref _selectedTrip, value);
        }

        #endregion

        
        #region Commands

        /// <summary>
        /// Команда для сохранения оценки поездки
        /// </summary>
        public ICommand SaveRatingCommand { get; private set; }

        #endregion


        #region Initialization

        /// <summary>
        /// Инициализация команд
        /// </summary>
        private void InitializeCommands()
        {
            SaveRatingCommand = new RelayCommand(_ =>
            {
                try
                {
                    if (SelectedTrip == null) return;
                    _tripService.UpdateTrip(SelectedTrip);
                    Debug.WriteLine("Оценка сохранена!");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Ошибка: {ex.Message}");
                }
            });
        }

        #endregion


        #region Data Loading

        /// <summary>
        /// Загрузка завершенных поездок из сервиса
        /// </summary>
        private void LoadCompletedTrips()
        {
            var trips = _tripService.GetCompletedTrips();
            foreach (var trip in trips)
            {
                CompletedTrips.Add(trip);
            }

            // Альтернатива с использованием LINQ:
            // _tripService.GetCompletedTrips().ForEach(CompletedTrips.Add);
        }

        #endregion


        #region Helper Methods

        /// <summary>
        /// Сохранение оценки (дублирует функционал команды - требуется рефакторинг)
        /// </summary>
        private void SaveRating()
        {
            if (SelectedTrip == null) return;
            _tripService.UpdateTrip(SelectedTrip);
            MessageBox.Show("Оценка сохранена!");  // Прямое использование MessageBox во ViewModel (можно вынести в отдельный сервис)
        }

        #endregion
    }
}