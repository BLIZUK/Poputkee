using Poputkee.Core.Commands;
using Poputkee.Core.Models;
using Poputkee.Desktop.ViewModels;
using System.ComponentModel;
using System.Windows.Input;

public class BookRideViewModel : BaseViewModel
{
    public DateTime SelectedDate { get; set; }
    public ICommand SearchRidesCommand { get; }
}