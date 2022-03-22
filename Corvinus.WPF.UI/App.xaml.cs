using Corvinus.WPF.Common.Extensions;
using Corvinus.WPF.UI.Configuration;
using Corvinus.WPF.UI.Services;
using Corvinus.WPF.UI.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Corvinus.WPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? Host { get; private set; }

        public IConfiguration? Configuration { get; set; }

        public App()
        {
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureApp()
                .ConfigureServices((context, services) =>
                {
                    services.Configure<IConfiguration>(context.Configuration);
                    ConfigureServices(services, context.Configuration);
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await Host!.StartAsync();

            var mainWindow = Host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await Host!.StopAsync();
            base.OnExit(e);
        }

        private void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            Configuration = configuration;

            // Todo Add Logging Stuff Here

            services.AddAppConfig<ApplicationConfiguration>(Configuration);

            // Add Addtional Services Here:
            services.AddSingleton<IDbContext, DbContext>();
            services.AddSingleton<IResourceService, ResourceService>();


            //Add ViewModels Here:
            services.AddSingleton<MainWindowViewModel>();

            //Add Views Here:
            services.AddSingleton<MainWindow>();
        }
    }
}
