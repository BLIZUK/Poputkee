using Poputkee.Core.Models;
using Poputkee.Desktop.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels
{
    public class BookRideViewModel : BaseViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;



        private User _currentUser = new User { Id = Guid.NewGuid(), Name = "Test User" };



        private string _from;
        private string _to;
        private DateTime _selectedDate;
        private ObservableCollection<Trip> _foundTrips;

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

        public ObservableCollection<Trip> FoundTrips
        {
            get => _foundTrips;
            set => SetProperty(ref _foundTrips, value);
        }

        // Команды
        public ICommand FindRidesCommand { get; }
        public ICommand BookRideCommand { get; }

        public BookRideViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;

            SelectedDate = DateTime.Today;
            FoundTrips = new ObservableCollection<Trip>();

            FindRidesCommand = new RelayCommand(ExecuteFindRides, CanExecuteSearch);
            BookRideCommand = new RelayCommand<Trip>(ExecuteBookRide, CanExecuteBook);
        }

        private bool CanExecuteSearch() =>
            !string.IsNullOrEmpty(From) &&
            !string.IsNullOrEmpty(To);

        private async void ExecuteFindRides()
        {
            try
            {
                var allTrips = await _unitOfWork.Trips.GetAllAsync();

                FoundTrips.Clear();

                foreach (var trip in allTrips)
                {
                    if (trip.FromCity.Equals(From, StringComparison.OrdinalIgnoreCase) &&
                        trip.ToCity.Equals(To, StringComparison.OrdinalIgnoreCase) &&
                        trip.DepartureTime.Date == SelectedDate.Date)
                    {
                        FoundTrips.Add(trip);
                    }
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                Console.WriteLine($"Ошибка поиска: {ex.Message}");
            }
        }

        private bool CanExecuteBook(Trip trip) =>
            trip?.AvailableSeats > 0;

        private async void ExecuteBookRide(Trip trip)
        {
            try
            {
                var booking = new Booking
                {
                    TripId = trip.Id,
                    PassengerId = _userService.CurrentUser.Id, // Временное решение
                    BookedAt = DateTime.UtcNow
                };

                await _unitOfWork.Bookings.AddAsync(booking);
                trip.AvailableSeats--;
                await _unitOfWork.CommitAsync();

                // Обновить список
                FoundTrips.Remove(trip);
                FoundTrips.Add(trip);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка бронирования: {ex.Message}");
            }
        }
    }
}