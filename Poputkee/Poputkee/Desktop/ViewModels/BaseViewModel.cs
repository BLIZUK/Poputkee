using System; // Для базовых типов (например, Object, EventArgs)

using System.ComponentModel; // 1. INotifyPropertyChanged
/*
* Интерфейс из System.ComponentModel для автоматического обновления интерфейса
* Требуется для корректной работы привязок данных в WPF
*/

using System.Runtime.CompilerServices; // 2. CallerMemberName
/*
 - Атрибут из System.Runtime.CompilerServices
 - Автоматически подставляет имя вызывающего свойства
 - Позволяет избежать "магических строк":
 
 |```
 | //Вместо этого:
 |  SetField(ref _name, value, "Name");
 | //Можно писать так:
 |  SetProperty(ref _name, value);
 |```

 3. SetProperty vs SetField
 - SetProperty - современный метод с автоматическим определением имени свойства
 - SetField - устаревший метод, требующий явного указания имени

 4. EqualityComparer.Default.Equals
 - Безопасное сравнение значений, включая null-значения
 - Работает для всех типов данных

 | Пример:
 |```
 | public class UserViewModel : BaseViewModel
 |{
 |   private string _name;
 |   public string Name
 |   {
 |       get => _name;
 |       set => SetProperty(ref _name, value); // Автоматически вызывает OnPropertyChanged
 |   }
 |}
 |```
 */



namespace Poputkee.Desktop.ViewModels
{
    /// <summary>
    /// Базовый класс для всех ViewModel, реализующий уведомления об изменении свойств
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Событие для уведомления об изменении свойств
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged для указанного свойства
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства (если не указано, используется имя вызывающего свойства)</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Устанавливает значение поля и автоматически уведомляет об изменении свойства
        /// </summary>
        /// <typeparam name="T">Тип свойства</typeparam>
        /// <param name="field">Ссылка на поле</param>
        /// <param name="value">Новое значение</param>
        /// <param name="propertyName">Имя свойства (передается автоматически)</param>
        /// <returns>True, если значение изменилось</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            // Если значение не изменилось - ничего не делаем
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            // Устанавливаем новое значение
            field = value;

            // Уведомляем об изменении свойства
            OnPropertyChanged(propertyName);

            return true;
        }

        // Устаревший метод (лучше использовать SetProperty с CallerMemberName)
        // Оставлен для обратной совместимости
        protected bool SetField<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}