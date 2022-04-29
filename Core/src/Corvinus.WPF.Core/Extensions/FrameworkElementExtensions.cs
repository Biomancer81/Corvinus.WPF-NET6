// <copyright file="FrameworkElementExtensions.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Core.Extensions
{
    using System.Windows;

    /// <summary>
    /// FrameworkElement extensions.
    /// </summary>
    public static class FrameworkElementExtensions
    {
        /// <summary>
        /// Binds UI element to its ViewModel.
        /// </summary>
        /// <param name="element">FrameworkElement instance.</param>
        /// <param name="viewmodel">Viewmodel instance.</param>
        public static void BindTo(this FrameworkElement element, object viewmodel)
        {
            element.DataContext = viewmodel;
        }

        /// <summary>
        /// Unbinds UI Element to its ViewModel.
        /// </summary>
        /// <param name="element">FrameworkElement instance.</param>
        public static void Unbind(this FrameworkElement element)
        {
            element.DataContext = null;
        }
    }
}
