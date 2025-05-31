// System namespaces
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
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
        private bool _isLoading;

        #endregion

        #region Constructors

        /// <summary>
        /// Конструктор с внедрением зависимости сервиса поездок
        /// </summary>
        /// <param name="tripService">Сервис для работы с поездками</param>
        public ArchiveViewModel(ITripService tripService)
        {
            _tripService = tripService ??
                throw new ArgumentNullException(nameof(tripService));

            InitializeCommands();
            LoadCompletedTripsAsync();
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

        /// <summary>
        /// Флаг загрузки данных
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            private set => SetProperty(ref _isLoading, value);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Команда для сохранения оценки поездки
        /// </summary>
        public ICommand SaveRatingCommand { get; private set; }

        /// <summary>
        /// Команда для обновления списка поездок
        /// </summary>
        public ICommand RefreshCommand { get; private set; }

        #endregion

        #region Initialization

        /// <summary>
        /// Инициализация команд
        /// </summary>
        private void InitializeCommands()
        {
            SaveRatingCommand = new RelayCommand(async _ =>
            {
                await ExecuteSaveRatingAsync();
            });

            RefreshCommand = new RelayCommand(async _ =>
            {
                await LoadCompletedTripsAsync();
            });
        }

        #endregion

        #region Data Loading

        /// <summary>
        /// Асинхронная загрузка завершенных поездок
        /// </summary>
        private async Task LoadCompletedTripsAsync()
        {
            try
            {
                IsLoading = true;
                CompletedTrips.Clear();

                // Асинхронная загрузка данных
                var trips = await _tripService.GetCompletedTripsAsync();

                foreach (var trip in trips)
                {
                    CompletedTrips.Add(trip);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка загрузки поездок: {ex.Message}");
                MessageBox.Show("Не удалось загрузить список поездок",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            finally
            {
                IsLoading = false;
            }
        }

        #endregion

        #region Command Handlers

        /// <summary>
        /// Сохранение оценки асинхронно
        /// </summary>
        private async Task ExecuteSaveRatingAsync()
        {
            if (SelectedTrip == null) return;

            try
            {
                // Асинхронное обновление
                await _tripService.UpdateTripAsync(SelectedTrip);

                Debug.WriteLine("Оценка сохранена!");
                MessageBox.Show("Оценка успешно сохранена!",
                                "Успех",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Ошибка сохранения: {ex.Message}");
                MessageBox.Show("Не удалось сохранить оценку",
                                "Ошибка",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        #endregion
    }
}