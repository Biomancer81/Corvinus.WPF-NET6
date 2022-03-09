using Corvinus.WPF.Common.Commanding;
using Corvinus.WPF.Common.ViewModels;
using Corvinus.WPF.UI.Services;
using System.Windows;
using System.Windows.Input;

namespace Corvinus.WPF.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public IDataService DataService
        {
            get { return GetValue(() => DataService); }
            set { SetValue(() => DataService, value); }
        }

        public IResourceService ResourceService
        {
            get { return GetValue(() => ResourceService); }
            set { SetValue(() => ResourceService, value); }
        }

        public WindowState WindowState
        {
            get { return GetValue(() => WindowState); }
            set { SetValue(() => WindowState, value); }
        }

        public ICommand ChangeLocaleCommand
        {
            get { return GetValue(() => ChangeLocaleCommand); }
            set { SetValue(() => ChangeLocaleCommand, value); }
        }

        public ICommand ChangeThemeCommand
        {
            get { return GetValue(() => ChangeThemeCommand); }
            set { SetValue(() => ChangeThemeCommand, value); }
        }

        public ICommand CloseCommand
        {
            get { return GetValue(() => CloseCommand); }
            set { SetValue(() => CloseCommand, value); }
        }

        public ICommand MaximizeCommand
        {
            get { return GetValue(() => MaximizeCommand); }
            set { SetValue(() => MaximizeCommand, value); }
        }

        public ICommand MinimizeCommand
        {
            get { return GetValue(() => MinimizeCommand); }
            set { SetValue(() => MinimizeCommand, value); }
        }

        public MainWindowViewModel(IDataService dataService, IResourceService resourceService)
        {
            DataService = dataService;
            ResourceService = resourceService;

            CloseCommand = new RelayCommand(OnClose);
            MaximizeCommand = new RelayCommand(OnMaximize);
            MinimizeCommand = new RelayCommand(OnMinimize);

            ChangeLocaleCommand = new RelayCommand<string>(OnChangeLocale);
            ChangeThemeCommand = new RelayCommand<string>(OnChangeTheme);
        }

        private void OnChangeLocale(string localeCode)
        {
            if(localeCode != null && ResourceService.CurrentLocaleCode != localeCode)
            {
                ResourceService.ChangeLocale(localeCode);
            }
        }

        private void OnChangeTheme(string themeName)
        {
            if (themeName != null && ResourceService.CurrentTheme != themeName)
            {
                ResourceService.ChangeTheme(themeName);
            }
        }

        private void OnClose(object? parameter)
        {
            Application.Current.Shutdown();
        }

        private void OnMaximize(object? parameter)
        {
            WindowState = WindowState.Maximized;
        }

        private void OnMinimize(object? parameter)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
