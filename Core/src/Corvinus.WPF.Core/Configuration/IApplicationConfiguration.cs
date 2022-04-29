// <copyright file="IApplicationConfiguration.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Core.Configuration
{
    using System;

    /// <summary>
    /// The ApplicationConfiguration Interface.
    /// </summary>
    public interface IApplicationConfiguration
    {
        /// <summary>
        /// Gets or sets ApplicationId.
        /// </summary>
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ThemingEnabled.
        /// </summary>
        public bool ThemingEnabled { get; set; }
    }
}
