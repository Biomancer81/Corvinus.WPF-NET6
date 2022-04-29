// <copyright file="TestView.xaml.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.UI.Views
{
    using Corvinus.WPF.UI.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for TestView.xaml.
    /// </summary>
    public partial class TestView : Page
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model to use as a data context.</param>
        public TestView(TestViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
