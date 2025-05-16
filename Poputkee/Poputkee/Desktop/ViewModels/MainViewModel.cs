using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Poputkee.Core.Commands;

public class MainViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Trip> Trips { get; } = new ObservableCollection<Trip>();
    private Trip _selectedTrip;

    public Trip SelectedTrip
    {
        get => _selectedTrip;
        set { _selectedTrip = value; OnPropertyChanged(); }
    }

    public ICommand CreateTripCommand { get; }
    public ICommand BookSeatCommand { get; }
    public ICommand LoadTripsCommand { get; }

    public MainViewModel()
    {
        // Инициализация команд
        LoadTripsCommand = new RelayCommand(LoadTrips, CanLoadTrips);
        CreateTripCommand = new RelayCommand(CreateTrip);
        BookSeatCommand = new RelayCommand(BookSeat, CanBookSeat);

        // Пример данных (можно удалить после подключения БД)
        LoadSampleData();
    }

    private void LoadSampleData()
    {
        Trips.Add(new Trip
        {
            DriverName = "Иван Иванов",
            FromCity = "Москва",
            ToCity = "Санкт-Петербург",
            DepartureTime = DateTime.Now.AddHours(2),
            AvailableSeats = 3
        });
    }

    private void LoadTrips()
    {
        // TODO: Загрузка данных из БД через UnitOfWork
        // Пример:
        // var trips = _unitOfWork.Trips.GetAll();
        // Trips.Clear();
        // foreach (var trip in trips) Trips.Add(trip);
    }

    private bool CanLoadTrips() => true; // Всегда доступна

    private void CreateTrip()
    {
        var newTrip = new Trip
        {
            DriverName = "Новый Водитель",
            FromCity = "Город А",
            ToCity = "Город Б",
            DepartureTime = DateTime.Now.AddDays(1),
            AvailableSeats = 4
        };
        Trips.Add(newTrip);

        // TODO: Сохранение в БД
        // await _unitOfWork.Trips.AddAsync(newTrip);
        // await _unitOfWork.CommitAsync();
    }

    private void BookSeat()
    {
        if (SelectedTrip?.AvailableSeats > 0)
        {
            SelectedTrip.Passengers.Add("Пассажир");
            SelectedTrip.AvailableSeats--;

            // TODO: Сохранение бронирования в БД
            // var booking = new Booking { TripId = SelectedTrip.Id, PassengerId = CurrentUser.Id };
            // await _unitOfWork.Bookings.AddAsync(booking);
            // await _unitOfWork.CommitAsync();
        }
    }

    private bool CanBookSeat() => SelectedTrip != null && SelectedTrip.AvailableSeats > 0;

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}