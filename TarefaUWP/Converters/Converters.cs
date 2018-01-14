using System;
using System.Globalization;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace TarefaUWP.Converters
{
    public class VisibleWhenZeroConverter : IValueConverter
    {
        public object Convert(object v, Type t, object p, string l) =>
            Equals(0d, (double)v) ? Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object v, Type t, object p, string l) => null;
    }

    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var data = (DateTime)value;

                return data.ToString("dd/MM/yyyy");
            }
            catch
            {
                return "01/01/0001";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return DateTime.ParseExact((string)value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
    }
    public class ValorToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                CultureInfo c = new CultureInfo("pt-BR");
                var data =  (double)value;

                return data.ToString("N", c);
            }
            catch
            {
                return "0";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                CultureInfo c = new CultureInfo("pt-BR");
                return double.Parse((string)value,c);
            }
            catch
            {
                return 0;
            }
        }
    }

    public class RadioButtonToNullableIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (parameter != null && value != null)
            {
                return parameter.ToString() == value.ToString();
            }

            return object.Equals(parameter, value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var radioButtonValue = parameter as string;
            var isChecked = System.Convert.ToBoolean(value);
            return isChecked ? System.Convert.ToInt32(radioButtonValue) : default(int?);
        }
    }

    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return new DateTimeOffset(((DateTime)value).ToUniversalTime());

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return ((DateTimeOffset)value).DateTime;
        }
    }
}
