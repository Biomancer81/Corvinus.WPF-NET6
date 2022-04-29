// <copyright file="BooleanToVisibilityConverter.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Resources.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// The converter for converting a boolean value to a visibility value.
    /// </summary>
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a <see cref="bool"/> value to a <see cref="Visibility"/> value.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="targetType">A <see cref="Type"/> defining the target.</param>
        /// <param name="parameter">The optional parameter for the converter.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> of the current system.</param>
        /// <returns>An <see cref="Visibility"/> object.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool flag)
            {
                if (parameter != null && bool.TryParse(parameter.ToString(), out bool param))
                {
                    flag = flag == param;
                }

                return flag ? Visibility.Visible : Visibility.Hidden;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        /// <summary>
        /// Converts a <see cref="Visibility"/> value to a <see cref="bool" /> value.
        /// Not Implemented.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="targetType">A <see cref="Type"/> defining the target.</param>
        /// <param name="parameter">The optional parameter for the converter.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> of the current system.</param>
        /// <returns>Always returns false.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return false;
        }
    }
}
