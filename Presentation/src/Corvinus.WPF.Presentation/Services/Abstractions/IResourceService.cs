// <copyright file="IResourceService.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Services
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface defining a resource service.
    /// </summary>
    public interface IResourceService
    {
        /// <summary>
        /// Gets or sets CurrentLocaleCode.
        /// </summary>
        string CurrentLocaleCode { get; set; }
        
        /// <summary>
        /// Gets or sets CurrentTheme.
        /// </summary>
        string CurrentTheme { get; set; }

        /// <summary>
        /// Changes the applications localization information.
        /// </summary>
        /// <param name="localeCode">The standard locale code for localizing application.</param>
        void ChangeLocale(string localeCode);

        /// <summary>
        /// Changes the applications theme dictionary.
        /// </summary>
        /// <param name="themeName">The name of the theme to be applied.</param>
        void ChangeTheme(string themeName);

        /// <summary>
        /// Gets a list of the available themes.
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of <see cref="string"/> values indicating theme names.</returns>
        List<string> GetThemes();

        /// <summary>
        /// Gets the <see cref="Uri"/> for the appropriate locale information.
        /// </summary>
        /// <param name="localeCode">The standard locale code for localizing application.</param>
        /// <param name="resourceName">The <see cref="string"/> representing what resource type your are looking for.</param>
        /// <returns>A valid <see cref="Uri"/> for mapping the resource dictionary.</returns>
        Uri GetLocaleUri(string localeCode, string resourceName);

        /// <summary>
        /// Gets the <see cref="Uri"/> for the appropriate theme resource.
        /// </summary>
        /// <param name="themeName">The <see cref="string"/> representing the name of the theme.</param>
        /// <returns>A valid <see cref="Uri"/> for mapping the resource dictionary.</returns>
        Uri GetThemeUri(string themeName);
    }
}
