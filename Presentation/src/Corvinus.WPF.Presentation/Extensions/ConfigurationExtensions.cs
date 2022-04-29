// <copyright file="ConfigurationExtensions.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Extensions
{
    using Corvinus.WPF.Presentation.Services;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Controls;

    /// <summary>
    /// Extensions used for App Configuration.
    /// </summary>
    public static class ConfigurationExtensions
    {
        /// <summary>
        /// Adds Views.
        /// </summary>
        /// <param name="services">The current instance of <see cref="IServiceCollection"/>.</param>
        /// <returns>The configured instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddViews(this IServiceCollection services)
        {
            List<Type> types = Assembly.GetCallingAssembly().GetTypes().Where(t => t.Name.EndsWith("View") || t.Name.EndsWith("Window")).ToList();
            PageNavigationService navigationService = new PageNavigationService();

            foreach (Type type in types)
            {
                if (type.Name.EndsWith("View") && type == typeof(Page))
                {
                    navigationService.AddView(type.Name, type);
                }

                services.AddSingleton(type);
            }

            services.AddSingleton<PageNavigationService>(navigationService);

            return services;
        }
    }
}
