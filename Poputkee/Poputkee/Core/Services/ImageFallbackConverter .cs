// Poputkee.Core/Services/ImageFallbackConverter.cs
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Poputkee.Core.Services
{
    public class ImageFallbackConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string url && !string.IsNullOrWhiteSpace(url))
            {
                try
                {
                    return new BitmapImage(new Uri(url, UriKind.Absolute));
                }
                catch
                {
                    // Обработка ошибок загрузки
                }
            }

            // Возвращаем дефолтную аватарку
            return new BitmapImage(new Uri("https://i.pravatar.cc/150?img=0", UriKind.Absolute));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}