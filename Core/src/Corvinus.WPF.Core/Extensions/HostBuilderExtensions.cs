// <copyright file="HostBuilderExtensions.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Core.Extensions
{
    using System.IO;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Extensions for <see cref="IHostBuilder"/>.
    /// </summary>
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// Adds appsettings.json files to the application.
        /// </summary>
        /// <param name="builder">The current instance of <see cref="IHostBuilder"/>.</param>
        /// <returns>The configured instance of <see cref="IHostBuilder"/>.</returns>
        public static IHostBuilder ConfigureApp(this IHostBuilder builder)
        {
            return builder.ConfigureAppConfiguration((context, builder) =>
            {
                IHostEnvironment env = context.HostingEnvironment;
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
                builder.AddEnvironmentVariables(prefix: "DOTNET_ENVIRONMENT");
            });
        }
    }
}
