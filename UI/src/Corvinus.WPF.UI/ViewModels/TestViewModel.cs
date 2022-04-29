// <copyright file="TestViewModel.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.UI.ViewModels
{
    using Corvinus.WPF.Core.Commanding;
    using Corvinus.WPF.Core.ViewModels;
    using Corvinus.WPF.Presentation.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// Test View Model.
    /// </summary>
    public class TestViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestViewModel"/> class.
        /// </summary>
        /// <param name="resourceService">The host instance of <see cref="IResourceService"/>.</param>
        public TestViewModel(IResourceService resourceService)
        {
            ResourceService = resourceService;

            ChangeLocaleCommand = new RelayCommand<string>(OnChangeLocale);
            ChangeThemeCommand = new RelayCommand<string>(OnChangeTheme);
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

        /// <summary>
        /// Gets or sets ResourceService.
        /// </summary>
        public IResourceService ResourceService
        {
            get { return GetValue(() => ResourceService); }
            set { SetValue(() => ResourceService, value); }
        }

        private void OnChangeLocale(string localeCode)
        {
            if (localeCode != null && ResourceService.CurrentLocaleCode != localeCode)
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
