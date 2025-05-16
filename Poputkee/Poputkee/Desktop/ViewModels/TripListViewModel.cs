using Poputkee.Core.Interfaces;
using Poputkee.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class TripListViewModel : INotifyPropertyChanged
{
    private readonly IUnitOfWork _unitOfWork;
    public ObservableCollection<Trip> Trips { get; } = new ObservableCollection<Trip>();

    public TripListViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        LoadTrips();
    }

    private async void LoadTrips()
    {
        var trips = await _unitOfWork.Trips.GetAllAsync();
        Trips.Clear();
        foreach (var trip in trips) Trips.Add(trip);
    }

    // Реализация INotifyPropertyChanged...
}