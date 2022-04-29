using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace Corvinus.WPF.UI.Services
{
    public class ResourceService : IResourceService
    {
        public string CurrentLocaleCode { get; set; } = "en-US";
        public string CurrentTheme { get; set; } = "Default";

        public ILogger Logger { get; set; }

        public ResourceService(ILogger logger)
        {
            Logger = logger;
        }

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

        public Uri GetLocaleUri(string localeCode, string resourceName)
        {
            return new Uri(@"\Resources\Localization\" + localeCode + @"\" + resourceName + ".xaml", UriKind.Relative);
        }

        public List<string> GetThemes()
        {
            List<string> result = new List<string>();
            return result;
        }

        public Uri GetThemeUri(string themeName)
        {
            return new Uri(@"\Resources\Themes\" + themeName + ".xaml", UriKind.Relative);
        }

        private void AddBaseDictionaries(Collection<ResourceDictionary> mergedDictionaries)
        {
            ResourceDictionary? baseDictionary = Application.LoadComponent(new Uri(@"\Resources\Base.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary? controlStylesDictionary = Application.LoadComponent(new Uri(@"\Resources\ControlStyles.xaml", UriKind.Relative)) as ResourceDictionary;
            ResourceDictionary? imageGeometryDictionary = Application.LoadComponent(new Uri(@"\Resources\ImageGeometry.xaml", UriKind.Relative)) as ResourceDictionary;

            if(baseDictionary != null)
                mergedDictionaries.Add(baseDictionary);

            if (controlStylesDictionary != null)
                mergedDictionaries.Add(controlStylesDictionary);

            if (imageGeometryDictionary != null)
                mergedDictionaries.Add(imageGeometryDictionary);
        }

        private void AddLocaleDictionaries(Collection<ResourceDictionary> mergedDictionaries)
        {
            ResourceDictionary? stringResourceDictionary = Application.LoadComponent(GetLocaleUri(CurrentLocaleCode, "StringResources")) as ResourceDictionary;

            if(stringResourceDictionary != null)
            {
                mergedDictionaries.Add(stringResourceDictionary);
            }
        }

        private void AddThemeDictionary(Collection<ResourceDictionary> mergedDictionaries)
        {
            ResourceDictionary? themeDictionary = Application.LoadComponent(GetThemeUri(CurrentTheme)) as ResourceDictionary;

            if (themeDictionary != null)
                mergedDictionaries.Add(themeDictionary);
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
                Logger.LogError("SetCultureInfo Failed: " + ex.Message);

            }
        }
    }
}
