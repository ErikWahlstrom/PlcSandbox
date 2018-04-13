namespace TestApp
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class FlattenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var array = (double[,])value;
            var returnArray = new List<double>();
            if (array == null)
            {
                return null;
            }

            foreach (var item in array)
            {
                returnArray.Add(item);
            }

            return returnArray.ToArray();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
