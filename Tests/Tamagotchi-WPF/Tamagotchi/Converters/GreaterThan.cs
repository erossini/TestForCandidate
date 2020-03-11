using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Tamagotchi.Converters
{
    public class GreaterThan : MarkupExtension, IValueConverter
    { 
        public GreaterThan(double opnd)
        {
            Operand = opnd;
        }

        /// <summary>
        /// Converter returns true if value is greater than this.
        /// </summary>
        protected double Operand { get; set; }
        
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) > Operand;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
