using AppControleFinanceiro.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControleFinanceiro.Libraries.Convertes
{
    public class TransactionValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Transaction t = (Transaction) value;
            if(t == null)
            {
                return string.Empty;
            }
            else if (t.Type == Enum.TransactionType.Income)
            {
                return t.Value.ToString("C");
            }
            else
            {
                return "-" + t.Value.ToString("C");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
