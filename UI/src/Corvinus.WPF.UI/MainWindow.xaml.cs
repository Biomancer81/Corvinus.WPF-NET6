// <copyright file="MainWindow.xaml.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.UI
{
    using Corvinus.WPF.Modules.UI;
    using Corvinus.WPF.UI.ViewModels;
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window, IModuleView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="viewModel">The view model to be used as the DataContext.</param>
        public MainWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            ModuleDescription = "Main Window";
            ModuleId = Guid.NewGuid();
            ModuleName = "MainWindow";
        }

        /// <inheritdoc/>
        public string ModuleDescription { get; set; }

        /// <inheritdoc/>
        public Guid ModuleId { get; set; }

        /// <inheritdoc/>
        public string ModuleName { get; set; }
    }
}
