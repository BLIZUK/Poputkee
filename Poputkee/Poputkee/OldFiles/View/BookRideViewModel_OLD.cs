/*
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Poputkee.Desktop.ViewModels.MainMenu;
public class BookRideViewModel : INotifyPropertyChanged
{
    private DateTime _selectedDate = DateTime.Now;
    public DateTime SelectedDate;

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


    private void SearchRides()
    {
        // Логика поиска...
        MessageBox.Show($"Ищем поездки на {SelectedDate:dd.MM.yyyy}");
    }
}
 */