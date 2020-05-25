// ***********************************************************************
// Assembly         : StartupProjectManager.Ui
// Author           : Rku
// Created          : 05-11-2020
// ***********************************************************************
namespace StartupProjectManager.Ui.Converters
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    /// <summary>
    /// Class ByteArrayToBitmapImageConverter.
    /// Implements the <see cref="System.Windows.Data.IValueConverter" />
    /// </summary>
    /// <seealso cref="System.Windows.Data.IValueConverter" />
    public class ByteArrayToBitmapImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts the byte array to bit map image.
        /// </summary>
        /// <param name="imageByteArray">The image byte array.</param>
        /// <returns>BitmapImage.</returns>
        public static BitmapImage ConvertByteArrayToBitMapImage(byte[] imageByteArray)
        {
            var img = new BitmapImage
            {
                StreamSource = new MemoryStream(imageByteArray)
            };
            return img;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
        public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is byte[] imageByteArray))
            {
                return null;
            }

            return ConvertByteArrayToBitMapImage(imageByteArray);
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>A converted value. If the method returns <see langword="null" />, the valid null value is used.</returns>
        public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
