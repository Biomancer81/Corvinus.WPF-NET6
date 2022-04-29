// <copyright file="ConfigurationExtensions.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Core.Extensions
{
    using Corvinus.WPF.Core.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Extensions used for App Configuration.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Adds an instance of ApplicationConfiguration to the application.
        /// </summary>
        /// <typeparam name="T">The type to contain the ApplicationConfiguration.</typeparam>
        /// <param name="services">The current instance of <see cref="IServiceCollection"/>.</param>
        /// <param name="configuration">The current instance of <see cref="IConfiguration" />.</param>
        /// <returns>The current instance of <see cref="IServiceCollection"/> with added configuration.</returns>
        public static IServiceCollection AddAppConfig<T>(this IServiceCollection services, IConfiguration configuration)
        {
            T appConfig = configuration.GetSection("ApplicationConfiguration").Get<T>();

            if (appConfig != null)
            {
                services.AddSingleton(typeof(T), appConfig);
            }

            return services;
        }

        /// <summary>
        /// Adds all view models in the library.
        /// </summary>
        /// <param name="services">The current instance of <see cref="IServiceCollection"/>.</param>
        /// <returns>The configured instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            List<Type> types = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name.EndsWith("ViewModel")).ToList();

            foreach (Type type in types)
            {
                services.AddSingleton(type);
            }

            return services;
        }
    }
}
