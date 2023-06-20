using AppControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Libraries.Convertes
{
    public class TransactionValueColorConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Transaction t = (Transaction)value;
            if (t == null)
            {
                return Colors.Black; 
            }
            else if (t.Type == Enum.TransactionType.Income)
            {
                return Color.FromArgb("#FF939E5A");
            }
            else
            {
                return Colors.Red;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
