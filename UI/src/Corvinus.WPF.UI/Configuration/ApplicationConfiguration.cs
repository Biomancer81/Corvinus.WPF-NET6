// <copyright file="ApplicationConfiguration.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.UI.Configuration
{
    using System;
    using Corvinus.WPF.Core.Configuration;

    /// <summary>
    /// An object representing the ApplicationConfiguration.
    /// </summary>
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationConfiguration"/> class.
        /// </summary>
        public ApplicationConfiguration()
        {
        }

        /// <inheritdoc/>
        public Guid ApplicationId { get; set; }

        /// <inheritdoc/>
        public bool ThemingEnabled { get; set; }
    }
}
