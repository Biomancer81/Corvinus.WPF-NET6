// <copyright file="DbContext.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.UI.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// The current DbContext.
    /// </summary>
    public class DbContext : IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbContext"/> class.
        /// </summary>
        public DbContext()
        {
        }

        /// <inheritdoc/>
        public List<string> GetDataSample()
        {
            return new List<string> { "One", "Two", "Three", "Four", "Five" };
        }
    }
}
