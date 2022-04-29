// <copyright file="INavigationService.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Core.Services
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// The interface definition for a NavigationService.
    /// </summary>
    /// <typeparam name="T">The class type the interface uses.</typeparam>
    public interface INavigationService<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets BackJournal.
        /// </summary>
        public Stack<T> BackJournal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether EnableNavigationHistory.
        /// </summary>
        public bool EnableNavigationHistory { get; set; }

        /// <summary>
        /// Gets or sets ForwardJournal.
        /// </summary>
        public Stack<T> ForwardJournal { get; set; }

        /// <summary>
        /// Gets a value indicating whether CanNavigateBack.
        /// </summary>
        public bool CanNavigateBack
        {
            get { return EnableNavigationHistory && BackJournal.Count > 0; }
        }

        /// <summary>
        /// Gets a value indicating whether CanNavigateForward.
        /// </summary>
        public bool CanNavigateForward
        {
            get { return EnableNavigationHistory && ForwardJournal.Count > 0; }
        }

        /// <summary>
        /// Gets or sets CurrentObject.
        /// </summary>
        public T? CurrentView { get; set; }

        /// <summary>
        /// Gets or sets Host.
        /// </summary>
        public static IHost? Host { get; set; }

        /// <summary>
        /// Gets or sets Views.
        /// </summary>
        public Dictionary<string, Type> Views { get; set; }

        /// <summary>
        /// Initializes the services with an instance of <see cref="IHost"/>.
        /// </summary>
        /// <param name="host">The instance of <see cref="IHost"/> used to initalize the service.</param>
        public void InitializeService(IHost host);

        /// <summary>
        /// Adds a single view to the Views dictionary.
        /// </summary>
        /// <param name="typeName">The type name to associate with the view.</param>
        /// <param name="type">The view <see cref="Type"/>.</param>
        public void AddView(string typeName, Type type);

        /// <summary>
        /// Adds multiple views to the Views dictionary.
        /// </summary>
        /// <param name="types">A <see cref="Dictionary{TKey, TValue}"/> where TKey is a <see cref="string"/> and TValue is a <see cref="Type"/>.</param>
        public void AddViews(Dictionary<string, Type> types);

        /// <summary>
        /// Navigates to the view associated with <paramref name="typeName"/>.
        /// </summary>
        /// <param name="typeName">A string containing the name associated with the view.</param>
        public void Navigate(string typeName);

        /// <summary>
        /// Navigates back one view if navigation history is enabled.
        /// </summary>
        public void NavigateBack();

        /// <summary>
        /// Navigates forward one view if navigation history is enabled.
        /// </summary>
        public void NavigateForward();
    }
}
