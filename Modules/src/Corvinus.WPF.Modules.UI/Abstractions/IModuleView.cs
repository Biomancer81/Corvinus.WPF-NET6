// <copyright file="IModuleView.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Modules.UI
{
    using Corvinus.WPF.Modules;

    /// <summary>
    /// The interface for designing module views.
    /// </summary>
    public interface IModuleView : IModule
    {
        /// <summary>
        /// Gets or sets ModuleDescription.
        /// </summary>
        string ModuleDescription { get; set; }
    }
}
