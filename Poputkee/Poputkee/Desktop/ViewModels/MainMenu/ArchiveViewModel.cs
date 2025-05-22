using Poputkee.Core.Models;
using Poputkee.Core.Services;
using Poputkee.Core.Interfaces;
using Poputkee.Desktop.ViewModels;
using System.Collections.ObjectModel;

public class ArchiveViewModel : BaseViewModel
{
    private readonly ITripService _tripService;
    public ObservableCollection<Trip> CompletedTrips { get; } = new ObservableCollection<Trip>();

    public ArchiveViewModel(ITripService tripService)
    {
        _tripService = tripService;
        LoadCompletedTrips();
    }

    private void LoadCompletedTrips()
    {
        var trips = _tripService.GetCompletedTrips();
        foreach (var trip in trips)
        {
            CompletedTrips.Add(trip);
        }
    }
}