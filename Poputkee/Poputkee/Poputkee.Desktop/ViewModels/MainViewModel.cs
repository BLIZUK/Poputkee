// Poputkee.Desktop/ViewModels/MainViewModel.cs
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly IUnitOfWork _unitOfWork;
    private ObservableCollection<Trip> _trips;
    private Trip _selectedTrip;

    public ObservableCollection<Trip> Trips
    {
        get => _trips;
        set { _trips = value; OnPropertyChanged(); }
    }

    public Trip SelectedTrip
    {
        get => _selectedTrip;
        set { _selectedTrip = value; OnPropertyChanged(); }
    }

    public ICommand LoadTripsCommand { get; }
    public ICommand BookTripCommand { get; }

    public MainViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        LoadTripsCommand = new RelayCommand(async () => await LoadTrips());
        BookTripCommand = new RelayCommand(async () => await BookTrip());
    }

    private async Task LoadTrips()
    {
        var trips = await _unitOfWork.Trips.GetAllAsync();
        Trips = new ObservableCollection<Trip>(trips);
    }

    private async Task BookTrip()
    {
        if (SelectedTrip != null)
        {
            var booking = new Booking
            {
                TripId = SelectedTrip.Id,
                PassengerId = CurrentUser.Id, // Предположим, что CurrentUser существует
                BookedAt = DateTime.UtcNow
            };
            await _unitOfWork.Bookings.AddAsync(booking);
            await _unitOfWork.CommitAsync();
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}