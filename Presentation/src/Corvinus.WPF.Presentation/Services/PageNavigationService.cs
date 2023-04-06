// <copyright file="PageNavigationService.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Services
{
    using Corvinus.WPF.Core.Services;
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;

    /// <summary>
    /// A class used for page navigation.
    /// </summary>
    public class PageNavigationService : NavigationService<Page>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageNavigationService"/> class.
        /// </summary>
        public PageNavigationService() 
            : base()
        {
            // EnableNavigationHistory = false;
            // BackJournal = new Stack<Page>();
            // ForwardJournal = new Stack<Page>();
            // this.Host = null;
            // Views = new Dictionary<string, Type>();
            // CurrentView = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PageNavigationService"/> class.
        /// </summary>
        /// <param name="viewTypes">A dictionary containing the view names and associated types.</param>
        public PageNavigationService(Dictionary<string, Type> viewTypes) 
            : base(viewTypes)
        {
            // EnableNavigationHistory = false;
            // BackJournal = new Stack<Page>();
            // ForwardJournal = new Stack<Page>();
            // Host = null;
            // Views = viewTypes;
            // CurrentView = null;
        }

        ///// <summary>
        ///// Gets BackJournal.
        ///// </summary>
        // public Stack<Page> BackJournal { get; private set; }

        ///// <summary>
        ///// Gets a value indicating whether EnableNavigationHistory.
        ///// </summary>
        // public bool EnableNavigationHistory { get; private set; }
        
        ///// <summary>
        ///// Gets ForwardJournal.
        ///// </summary>
        // public Stack<Page> ForwardJournal { get; private set; }

        ///// <summary>
        ///// Gets a value indicating whether CanNavigateBack.
        ///// </summary>
        // public bool CanNavigateBack
        // {
        //     get { return EnableNavigationHistory && BackJournal.Count > 0; }
        // }

        ///// <summary>
        ///// Gets a value indicating whether CanNavigateForward.
        ///// </summary>
        // public bool CanNavigateForward
        // {
        //     get { return EnableNavigationHistory && ForwardJournal.Count > 0; }
        // }

        ///// <summary>
        ///// Gets or sets CurrentObject.
        ///// </summary>
        // public Page? CurrentView { get; set; }

        ///// <summary>
        ///// Gets Host.
        ///// </summary>
        // internal static IHost? Host { get; private set; }

        // private Dictionary<string, Type> Views;

        ///// <summary>
        ///// Initializes the services with an instance of <see cref="IHost"/>.
        ///// </summary>
        ///// <param name="host">The instance of <see cref="IHost"/> used to initalize the service.</param>
        // public void InitializeService(IHost host)
        // {
        //     Host = host;
        // }

        ///// <summary>
        ///// Adds a single view to the Views dictionary.
        ///// </summary>
        ///// <param name="typeName">The type name to associate with the view.</param>
        ///// <param name="type">The view <see cref="Type"/>.</param>
        // public void AddView(string typeName, Type type)
        // {
        //    Views.Add(typeName, type);
        // }

        ///// <summary>
        ///// Adds multiple views to the Views dictionary.
        ///// </summary>
        ///// <param name="types">A <see cref="Dictionary{TKey, TValue}"/> where TKey is a <see cref="string"/> and TValue is a <see cref="Type"/>.</param>
        // public void AddViews(Dictionary<string, Type> types)
        // {
        //    foreach (var type in types)
        //    {
        //        AddView(type.Key, type.Value);
        //    }
        // }

        ///// <summary>
        ///// Navigates to the view associated with <paramref name="typeName"/>.
        ///// </summary>
        ///// <param name="typeName">A string containing the name associated with the view.</param>
        // public void Navigate(string typeName)
        // {
        //    Type type = Views[typeName];

        // if(CurrentView != null && EnableNavigationHistory)
        // {
        //     BackJournal.Push(CurrentView);
        //        ForwardJournal.Clear();
        //    }

        // CurrentView = (Page?)Host!.Services.GetService(type) != null ? (Page?)Host!.Services.GetService(type) : null;

        // return;
        // }

        ///// <summary>
        ///// Navigates back one view if navigation history is enabled.
        ///// </summary>
        // public void NavigateBack()
        // {
        //    if (CanNavigateBack)
        //    {
        //        if(CurrentView != null && CanNavigateForward)
        //        {
        //            ForwardJournal.Push(CurrentView);
        //        }

        // CurrentView = BackJournal.Pop();

        // return;
        // }
        // }

        ///// <summary>
        ///// Navigates forward one view if navigation history is enabled.
        ///// </summary>
        // public void NavigateForward()
        // {
        //    if (CanNavigateForward)
        //    {
        //        if(CurrentView != null && CanNavigateBack)
        //        {
        //            BackJournal.Push(CurrentView);
        //        }

        // CurrentView = ForwardJournal.Pop();

        // return;
        // }
        // }
    }
}
