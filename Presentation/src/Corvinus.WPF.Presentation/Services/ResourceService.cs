// <copyright file="ResourceService.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Services
{
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
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceService"/> class.
        /// </summary>
        public ResourceService()
        {
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

            if (mergedDictionaries.Count > 0)
                mergedDictionaries.Clear();

            AddThemeDictionary(mergedDictionaries);

            AddLocaleDictionaries(mergedDictionaries);

            AddBaseDictionaries(mergedDictionaries);

            configureAction.Invoke(mergedDictionaries);
        }

        /// <inheritdoc/>
        public Uri GetLocaleUri(string localeCode, string resourceName)
        {
            return new Uri(@"\Resources\Localization\" + localeCode + @"\" + resourceName + ".xaml", UriKind.Relative);
        }

        /// <inheritdoc/>
        public List<string> GetThemes()
        {
            List<string> result = new List<string>();
            return result;
        }

        /// <inheritdoc/>
        public Uri GetThemeUri(string themeName)
        {
            return new Uri(@"\Resources\Themes" + themeName + ".xaml", UriKind.Relative);
        }

        private void AddBaseDictionaries(Collection<ResourceDictionary> mergedDictionaries)
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

        private void AddLocaleDictionaries(Collection<ResourceDictionary> mergedDictionaries)
        {
            ResourceDictionary? localeDictionary = Application.LoadComponent(GetLocaleUri(CurrentLocaleCode, "StringResources")) as ResourceDictionary;

            if (localeDictionary != null)
                mergedDictionaries.Add(localeDictionary);
        }

        private void AddThemeDictionary(Collection<ResourceDictionary> mergedDictionaries)
        {
            ResourceDictionary? themeDictionary = Application.LoadComponent(GetThemeUri(CurrentTheme)) as ResourceDictionary;
            
            if (themeDictionary != null)
                mergedDictionaries.Add(themeDictionary);
        }

        private ResourceDictionary GetExternalDictionary(Uri uri)
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = uri;
            return resourceDictionary;
        }

        private void SetCultureInfo()
        {
            try
            {
                CultureInfo ci = new CultureInfo(CurrentLocaleCode);
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }
            catch(Exception ex)
            {
            }
        }
    }
}
