using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfPatientManagement.Converters
{
    public class AdmissionStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isAdmitted)
            {
                if (targetType == typeof(Brush))
                {
                    return isAdmitted ? Brushes.Green : Brushes.Red;
                }
                else if(targetType == typeof(string))
                {
                    return isAdmitted ? "접수 완료" : "미접수";
                }
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}