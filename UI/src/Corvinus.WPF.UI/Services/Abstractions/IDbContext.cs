// <copyright file="IDbContext.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.UI.Services
{
    using System.Collections.Generic;

    /// <summary>
    /// A definition for <see cref="IDbContext"/>.
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Returns a list containing Data samples.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of type <see cref="string"/>.</returns>
        public List<string> GetDataSample();
    }
}
