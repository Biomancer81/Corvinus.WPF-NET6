// <copyright file="ResourceService.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Services
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Threading;
    using System.Windows;

    /// <summary>
    /// The default implementation of <see cref="IResourceService"/>.
    /// </summary>
    public class ResourceService : IResourceService
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceService"/> class.
        /// </summary>
        /// <param name="logger">The logger instance for the service.</param>
        public ResourceService(ILogger<ResourceService> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public string CurrentLocaleCode { get; set; } = "en-US";

        /// <inheritdoc/>
        public string CurrentTheme { get; set; } = "Default";

        /// <inheritdoc/>
        public void ChangeLocale(string localeCode)
        {
            CurrentLocaleCode = localeCode;

            SetCultureInfo();

            Collection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries.Count > 0)
                mergedDictionaries.Clear();

            AddThemeDictionary(mergedDictionaries);

            AddLocaleDictionaries(mergedDictionaries);

            AddBaseDictionaries(mergedDictionaries);
        }

        /// <inheritdoc/>
        public void ChangeTheme(string themeName)
        {
            CurrentTheme = themeName;

            Collection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            if (mergedDictionaries.Count > 0)
                mergedDictionaries.Clear();

            AddThemeDictionary(mergedDictionaries);

            AddLocaleDictionaries(mergedDictionaries);

            AddBaseDictionaries(mergedDictionaries);
        }

        /// <summary>
        /// Changes the applications theme dictionary, with the ability to add additional dictionaries through the configureAction.
        /// </summary>
        /// <param name="themeName">The name of the theme to be applied.</param>
        /// <param name="configureAction">Allows you to further modify the MergedDictionaries.</param>
        public void ChangeTheme(string themeName, Action<Collection<ResourceDictionary>> configureAction)
        {
            CurrentTheme = themeName;

            Collection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            Collection<ResourceDictionary> newMergedDictionaries = new ();

            if (mergedDictionaries.Count > 0)
                mergedDictionaries.Clear();

            AddThemeDictionary(newMergedDictionaries);

            AddLocaleDictionaries(newMergedDictionaries);

            AddBaseDictionaries(newMergedDictionaries);

            configureAction.Invoke(newMergedDictionaries);
        }

        /// <inheritdoc/>
        public Uri GetLocaleUri(string localeCode, string resourceName)
        {
            return new Uri(@"\Resources\Localization\" + localeCode + @"\" + resourceName + ".xaml", UriKind.Relative);
        }

        /// <inheritdoc/>
        public List<string> GetThemes()
        {
            List<string> result = new();
            return result;
        }

        /// <inheritdoc/>
        public Uri GetThemeUri(string themeName)
        {
            return new Uri(@"\Resources\Themes\" + themeName + ".xaml", UriKind.Relative);
        }

        private static void AddBaseDictionaries(Collection<ResourceDictionary> mergedDictionaries)
        {
            ResourceDictionary baseDictionary = GetExternalDictionary(new Uri(@"pack://application:,,,/Corvinus.WPF.Presentation;component/Resources/Base.xaml", UriKind.Absolute));
            ResourceDictionary? controlStylesDictionary = GetExternalDictionary(new Uri(@"pack://application:,,,/Corvinus.WPF.Presentation;component/Resources/ControlStyles.xaml", UriKind.Absolute));
            ResourceDictionary? imageGeometryDictionary = GetExternalDictionary(new Uri(@"pack://application:,,,/Corvinus.WPF.Presentation;component/Resources/ImageGeometry.xaml", UriKind.Absolute));

            if (baseDictionary != null)
                mergedDictionaries.Add(baseDictionary);

            if (controlStylesDictionary != null)
                mergedDictionaries.Add(controlStylesDictionary);

            if (imageGeometryDictionary != null)
                mergedDictionaries.Add(imageGeometryDictionary);
        }

        private static ResourceDictionary GetExternalDictionary(Uri uri)
        {
            ResourceDictionary resourceDictionary = new()
            {
                Source = uri
            };
            return resourceDictionary;
        }

        private void AddLocaleDictionaries(Collection<ResourceDictionary> mergedDictionaries)
        {
            if (Application.LoadComponent(GetLocaleUri(CurrentLocaleCode, "StringResources")) is ResourceDictionary localeDictionary)
                mergedDictionaries.Add(localeDictionary);
        }

        private void AddThemeDictionary(Collection<ResourceDictionary> mergedDictionaries)
        {
            if (Application.LoadComponent(GetThemeUri(CurrentTheme)) is ResourceDictionary themeDictionary)
                mergedDictionaries.Add(themeDictionary);
        }

        private void SetCultureInfo()
        {
            try
            {
                CultureInfo ci = new(CurrentLocaleCode);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }
            catch (Exception ex)
            {
                _logger.LogError($"ResourceService:SetCultureInfo:Failed with exception:{ex.Message}", ex);
            }
        }
    }
}
