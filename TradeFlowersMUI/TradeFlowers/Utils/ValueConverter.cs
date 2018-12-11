using System;

using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TradeFlowers.Utils
{
    internal class ValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (parameter != null && parameter.ToString() == "EN")
            //    return ((DateTime)value).ToString("MM-dd-yyyy");

            //return ((DateTime)value).ToString("dd.MM.yyyy");
            //string input = value as string;
            //switch (value)
            //{
            //    case 1:
            //        return Brushes.LightGreen;
            //    default:
            //        return DependencyProperty.UnsetValue;
            //}
            return ((int)value > 50) ? Brushes.LightGreen : DependencyProperty.UnsetValue;

            //return Brushes.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}