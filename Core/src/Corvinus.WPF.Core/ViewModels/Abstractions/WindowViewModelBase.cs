// <copyright file="WindowViewModelBase.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Core.ViewModels.Abstractions
{
    using System.Windows;
    using System.Windows.Input;
    using Corvinus.WPF.Core.Commanding;
    using Corvinus.WPF.Core.Configuration;

    /// <summary>
    /// The view model base for the MainWindowViewModel.
    /// </summary>
    public class WindowViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WindowViewModelBase"/> class.
        /// </summary>
        /// <param name="applicationConfiguration">The current instance of <see cref="IApplicationConfiguration"/>.</param>
        public WindowViewModelBase(IApplicationConfiguration applicationConfiguration)
        {
            CloseCommand = new RelayCommand(OnClose);
            MaximizeCommand = new RelayCommand(OnMaximize);
            MinimizeCommand = new RelayCommand(OnMinimize);
            ShowThemeCommand = new RelayCommand(OnShowTheme);

            ThemingEnabled = applicationConfiguration.ThemingEnabled;
        }

        /// <summary>
        /// Gets or sets CloseCommand.
        /// </summary>
        public ICommand CloseCommand
        {
            get { return GetValue(() => CloseCommand); }
            set { SetValue(() => CloseCommand, value); }
        }

        /// <summary>
        /// Gets or sets MaximizeCommand.
        /// </summary>
        public ICommand MaximizeCommand
        {
            get { return GetValue(() => MaximizeCommand); }
            set { SetValue(() => MaximizeCommand, value); }
        }

        /// <summary>
        /// Gets or sets MinimizeCommand.
        /// </summary>
        public ICommand MinimizeCommand
        {
            get { return GetValue(() => MinimizeCommand); }
            set { SetValue(() => MinimizeCommand, value); }
        }

        /// <summary>
        /// Gets or sets ShowThemeCommand.
        /// </summary>
        public ICommand ShowThemeCommand
        {
            get { return GetValue(() => ShowThemeCommand); }
            set { SetValue(() => ShowThemeCommand, value); }
        }

        /// <summary>
        /// Gets or sets WindowState.
        /// </summary>
        public WindowState WindowState
        {
            get { return GetValue(() => WindowState); }
            set { SetValue(() => WindowState, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ThemingEnabled.
        /// </summary>
        public bool ThemingEnabled
        {
            get { return GetValue(() => ThemingEnabled); }
            set { SetValue(() => ThemingEnabled, value); }
        }

        /// <summary>
        /// Handles chrome click of close button.
        /// </summary>
        /// <param name="parameter">An object which should be null.</param>
        internal void OnClose(object? parameter)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Handles chrome click of maximize button.
        /// </summary>
        /// <param name="parameter">An object which should be null.</param>
        internal void OnMaximize(object? parameter)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        /// <summary>
        /// Handles chrome click of minimize button.
        /// </summary>
        /// <param name="parameter">An object which should be null.</param>
        internal void OnMinimize(object? parameter)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Handles chrome click of maximize button.
        /// </summary>
        /// <param name="parameter">An object which should be null.</param>
        internal virtual void OnShowTheme(object? parameter)
        {
            return;
        }
    }
}
