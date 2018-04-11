namespace TestApp
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class ValueToArrayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var arr = (double[])value;
            int hej = int.Parse((string)parameter);
            return arr[hej];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var arr = new double[8];
            arr[int.Parse((string)parameter)] = double.Parse((string)value);
            return arr;
        }
    }
}
