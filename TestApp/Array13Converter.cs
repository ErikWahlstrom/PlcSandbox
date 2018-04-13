namespace TestApp
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class Array13Converter : IValueConverter
    {
        private double[,] lastReadArray = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var array = (double[,])value;
            if (array != null)
            {
                this.lastReadArray = array;
            }

            return array?[1, 3];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (this.lastReadArray != null)
            {
                this.lastReadArray[1, 3] = int.Parse((string)value);
            }

            return this.lastReadArray;
        }
    }
}
