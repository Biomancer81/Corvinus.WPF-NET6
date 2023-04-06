// <copyright file="TestView.xaml.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.UI.Views
{
    using Corvinus.WPF.Modules.UI;
    using Corvinus.WPF.UI.ViewModels;
    using System;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for TestView.xaml.
    /// </summary>
    public partial class TestView : Page, IModuleView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model to use as a data context.</param>
        public TestView(TestViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            ModuleDescription = "Test Page Module";
            ModuleId = Guid.NewGuid();
            ModuleName = "TestPageModule";
        }

        /// <inheritdoc/>
        public string ModuleDescription { get; set; }

        /// <inheritdoc/>
        public Guid ModuleId { get; set; }

        /// <inheritdoc/>
        public string ModuleName { get; set; }
    }
}
