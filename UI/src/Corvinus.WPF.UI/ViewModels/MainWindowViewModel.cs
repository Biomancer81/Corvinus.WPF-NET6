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
    using System.Windows.Input;

    /// <summary>
    /// The Main Windows view model.
    /// </summary>
    public class MainWindowViewModel : WindowViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="dataService">The host instance of <see cref="IDbContext"/>.</param>
        /// <param name="resourceService">The host instance of <see cref="IResourceService"/>.</param>
        /// <param name="applicationConfiguration">The host instance of <see cref="IApplicationConfiguration"/>.</param>
        public MainWindowViewModel(IDbContext dataService, IResourceService resourceService, IApplicationConfiguration applicationConfiguration) 
            : base(applicationConfiguration)
        {
            DataContext = dataService;
            ResourceService = resourceService;

            ChangeLocaleCommand = new RelayCommand<string>(OnChangeLocale);
            ChangeThemeCommand = new RelayCommand<string>(OnChangeTheme);
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
        /// Gets or sets ResourceService.
        /// </summary>
        public IResourceService ResourceService
        {
            get { return GetValue(() => ResourceService); }
            set { SetValue(() => ResourceService, value); }
        }

        /// <summary>
        /// Gets or sets ChangeLocaleCommand.
        /// </summary>
        public ICommand ChangeLocaleCommand
        {
            get { return GetValue(() => ChangeLocaleCommand); }
            set { SetValue(() => ChangeLocaleCommand, value); }
        }

        /// <summary>
        /// Gets or sets ChangeThemeCommand.
        /// </summary>
        public ICommand ChangeThemeCommand
        {
            get { return GetValue(() => ChangeThemeCommand); }
            set { SetValue(() => ChangeThemeCommand, value); }
        }

        private void OnChangeLocale(string localeCode)
        {
            if(localeCode != null && ResourceService.CurrentLocaleCode != localeCode)
            {
                ResourceService.ChangeLocale(localeCode);
            }
        }

        private void OnChangeTheme(string themeName)
        {
            if (themeName != null && ResourceService.CurrentTheme != themeName)
            {
                ResourceService.ChangeTheme(themeName);
            }
        }
    }
}
