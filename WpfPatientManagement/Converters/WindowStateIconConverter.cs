﻿using FontAwesome6;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace WpfPatientManagement.Converters
{
    public class WindowStateIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            WindowState state = (WindowState)value;
            if (state == WindowState.Normal)
            {
                return EFontAwesomeIcon.Regular_Square;
            }
            else
            {
                return EFontAwesomeIcon.Solid_DownLeftAndUpRightToCenter;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}