// System namespaces
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Poputkee.Core.Services
{
    /// <summary>
    /// Конвертер для преобразования null-значения в Visibility
    /// </summary>
    /// <remarks>
    /// Возвращает Visibility.Visible если значение не null,
    /// и Visibility.Collapsed если значение null
    /// </remarks>
    public class NullToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Implementation

        /// <summary>
        /// Прямое преобразование значения
        /// </summary>
        public object Convert(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            return value != null
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        /// <summary>
        /// Обратное преобразование (не реализовано)
        /// </summary>
        /// <exception cref="NotImplementedException">Всегда выбрасывает исключение</exception>
        public object ConvertBack(
            object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            throw new NotImplementedException(
                "Обратное преобразование не поддерживается");
        }

        #endregion
    }
}