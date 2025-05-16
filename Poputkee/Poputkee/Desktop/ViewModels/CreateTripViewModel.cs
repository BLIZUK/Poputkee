using Poputkee.Core.Commands;
using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System.ComponentModel;
using System.Windows.Input;

public class CreateTripViewModel : INotifyPropertyChanged
{
    private readonly IUnitOfWork _unitOfWork;
    private Trip _newTrip = new Trip();

    public Trip NewTrip
    {
        get => _newTrip;
        set { _newTrip = value; OnPropertyChanged(); }
    }

    public ICommand CreateTripCommand { get; }

    public CreateTripViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        CreateTripCommand = new RelayCommand(CreateTrip, CanCreateTrip);
    }

    private bool CanCreateTrip() =>
        !string.IsNullOrEmpty(NewTrip.DriverName) &&
        NewTrip.AvailableSeats > 0;

    private async void CreateTrip()
    {
        await _unitOfWork.Trips.AddAsync(NewTrip);
        await _unitOfWork.CommitAsync();
        NewTrip = new Trip(); // Очистка формы
    }

    // Реализация INotifyPropertyChanged...
}