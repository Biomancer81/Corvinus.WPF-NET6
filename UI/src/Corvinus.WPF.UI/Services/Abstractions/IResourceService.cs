using System;
using System.Collections.Generic;

namespace Corvinus.WPF.UI.Services
{
    public interface IResourceService
    {
        string CurrentLocaleCode { get; set; }

        string CurrentTheme { get; set; }

        void ChangeLocale(string localeCode);

        void ChangeTheme(string themeName);

        List<string> GetThemes();

        Uri GetLocaleUri(string localeCode, string resourceName);

        Uri GetThemeUri(string themeName);
    }
}
