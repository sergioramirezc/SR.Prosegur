using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SR.Prosegur.Converters
{
    public class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string color)
            {
                switch (color) 
                {
                    case "Active": return "Green";
                    case "Idle" : return "Gray";
                    case "Blocked": return "Red";
                    default: return "Gray";
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
    }
}
