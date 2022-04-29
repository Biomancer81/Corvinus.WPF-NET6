// <copyright file="MainWindowViewModel.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.UI.ViewModels
{
    using Corvinus.WPF.Core.Commanding;
    using Corvinus.WPF.Core.Configuration;
    using Corvinus.WPF.Core.ViewModels.Abstractions;
    using Corvinus.WPF.Presentation.Services;
    using Corvinus.WPF.UI.Services;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// The Main Windows view model.
    /// </summary>
    public class MainWindowViewModel : WindowViewModelBase
    {
        private PageNavigationService _pageNavigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="dataService">The host instance of <see cref="IDbContext"/>.</param>
        /// <param name="pageNavigationService">The host instance of <see cref="PageNavigationService"/>.</param>
        /// <param name="applicationConfiguration">The host instance of <see cref="IApplicationConfiguration"/>.</param>
        public MainWindowViewModel(IDbContext dataService, PageNavigationService pageNavigationService, IApplicationConfiguration applicationConfiguration) 
            : base(applicationConfiguration)
        {
            DataContext = dataService;
            _pageNavigationService = pageNavigationService;

            _pageNavigationService.InitializeService(App.Host!);
            _pageNavigationService.Navigate("TestView");
        }

        /// <summary>
        /// Gets or sets DataContext.
        /// </summary>
        public IDbContext DataContext
        {
            get { return GetValue(() => DataContext); }
            set { SetValue(() => DataContext, value); }
        }

        /// <summary>
        /// Gets or sets NavigationTarget.
        /// </summary>
        public Page NavigationTarget
        {
            get { return GetValue(() => NavigationTarget); }
            set { SetValue(() => NavigationTarget, value); }
        }
    }
}
