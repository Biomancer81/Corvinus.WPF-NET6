// <copyright file="App.xaml.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.UI
{
    using Corvinus.WPF.Core.Extensions;
    using Corvinus.WPF.Presentation.Services;
    using Corvinus.WPF.UI.Configuration;
    using Corvinus.WPF.UI.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Windows;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
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

        /// <summary>
        /// Gets Host.
        /// </summary>
        public static IHost? Host { get; private set; }

        /// <summary>
        /// Gets or sets Configuration.
        /// </summary>
        public IConfiguration? Configuration { get; set; }

        /// <summary>
        /// Configures application on startup.
        /// </summary>
        /// <param name="e">The <see cref="StartupEventArgs"/> for configuring the application.</param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            await Host!.StartAsync();

            var mainWindow = Host.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        /// <summary>
        /// Stops the application on exit.
        /// </summary>
        /// <param name="e">The <see cref="ExitEventArgs"/> for stopping the application.</param>
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

            // Add ViewModels Here:
            services.AddViewModels();

            // Add Views Here:
            services.AddViews();
        }
    }
}
