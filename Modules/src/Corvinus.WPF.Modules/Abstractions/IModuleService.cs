// <copyright file="IModuleService.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Modules.Abstractions
{
    /// <summary>
    /// IModuleService interface.
    /// </summary>
    public interface IModuleService : IModule
    {
        /// <summary>
        /// Gets or sets ModuleDescription.
        /// </summary>
        string ModuleDescription { get; set; }
    }
}
