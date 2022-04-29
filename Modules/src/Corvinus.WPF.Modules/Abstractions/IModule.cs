// <copyright file="IModule.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Modules
{
    using System;

    /// <summary>
    /// The IModule interface.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Gets or sets ModuleId.
        /// </summary>
        Guid ModuleId { get; set; }

        /// <summary>
        /// Gets or sets ModuleName.
        /// </summary>
        string ModuleName { get; set; }
    }
}
