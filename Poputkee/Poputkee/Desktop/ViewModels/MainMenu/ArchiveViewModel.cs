using Poputkee.Core.Models;
using Poputkee.Core.Services;
using Poputkee.Core.Interfaces;
using Poputkee.Desktop.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

public class ArchiveViewModel : BaseViewModel
{
    private readonly ITripService _tripService;
    private Trip _selectedTrip;
    public ObservableCollection<Trip> CompletedTrips { get; } = new ObservableCollection<Trip>();
    public ICommand SaveRatingCommand { get; }


    public ArchiveViewModel(ITripService tripService)
    {
        _tripService = tripService;
        LoadCompletedTrips();

        SaveRatingCommand = new RelayCommand(_ =>
        {
            if (SelectedTrip != null)
            {
                _tripService.UpdateTrip(SelectedTrip);
                MessageBox.Show("Оценка сохранена!");
            }
        });
    }


    public Trip SelectedTrip
    {
        get => _selectedTrip;
        set => SetProperty(ref _selectedTrip, value);
    }


    private void LoadCompletedTrips()
    {
        var trips = _tripService.GetCompletedTrips();
        foreach (var trip in trips)
        {
            CompletedTrips.Add(trip);
        }
    }


    private void SaveRating()
    {
        if (SelectedTrip == null) return;
        _tripService.UpdateTrip(SelectedTrip);
        MessageBox.Show("Оценка сохранена!");
    }
}