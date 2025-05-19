using Poputkee.Core.Models;
using Poputkee.Desktop.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

public class CreateRideViewModel : BaseViewModel
{
    private readonly IUnitOfWork _unitOfWork;

    // Свойства для привязки
    public string FromCity { get; set; }
    public string ToCity { get; set; }
    public DateTime? DepartureDate { get; set; } = DateTime.Now;
    public string DepartureTime { get; set; }
    public int AvailableSeats { get; set; }

    // Команда создания поездки
    public ICommand CreateRideCommand { get; }

    public CreateRideViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        CreateRideCommand = new RelayCommand(CreateRide, CanCreateRide);
    }

    // Проверка валидности данных
    private bool CanCreateRide()
    {
        return !string.IsNullOrEmpty(FromCity)
            && !string.IsNullOrEmpty(ToCity)
            && DepartureDate != null
            && TimeSpan.TryParse(DepartureTime, out _)
            && AvailableSeats > 0;
    }

    // Логика создания
    private async void CreateRide()
    {
        try
        {
            var trip = new Trip
            {
                FromCity = FromCity,
                ToCity = ToCity,
                DepartureTime = DepartureDate.Value.Date + TimeSpan.Parse(DepartureTime),
                AvailableSeats = AvailableSeats,
                DriverName = "Иван Иванов" // Замените на текущего пользователя
            };

            await _unitOfWork.Trips.AddAsync(trip);
            await _unitOfWork.CommitAsync();

            MessageBox.Show("Поездка успешно создана!");
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка: {ex.Message}");
        }
    }

    // Очистка формы
    private void ClearForm()
    {
        FromCity = "";
        ToCity = "";
        DepartureDate = DateTime.Now;
        DepartureTime = "";
        AvailableSeats = 0;
    }
}