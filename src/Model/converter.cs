using System;
using Windows.UI.Xaml.Data;

namespace Ficha
{
    class ConverterStrInt : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if((string)value == "")
            {
                return 0;
            }
            else
            {
                int date;
                try 
                { 
                    date = int.Parse((string)value);
                }
                catch (Exception)
                {
                    date = 0;
                }
                return date;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value.ToString();
        }
    }
}
