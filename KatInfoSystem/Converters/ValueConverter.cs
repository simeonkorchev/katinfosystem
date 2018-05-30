using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Presentation.Converters
{
    public abstract class ValueConverter<From, To> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert((From)value);
        }

        protected virtual To Convert(From value)
        {
            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ConvertBack((To)value);
        }

        protected virtual From ConvertBack(To value)
        {
            throw new NotSupportedException();
        }
    }
}
