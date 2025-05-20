using Poputkee.Desktop.ViewModels;
using System.ComponentModel;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels;
public class BookRideViewModel : INotifyPropertyChanged
{
    private DateTime _selectedDate;

    // Конструктор
    public BookRideViewModel()
    {
        ShowCreateRideCommand = new RelayCommand(ExecuteSearch);
    }


    public ICommand ShowCreateRideCommand { get; }


    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            _selectedDate = value;
            OnPropertyChanged(nameof(SelectedDate));
        }
    }


    private void ExecuteSearch(object parameter)
    {
        // Логика поиска поездок
    }

    // INotifyPropertyChanged реализация
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}