// <copyright file="ConfigurationExtensions.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Presentation.Extensions
{
    using Corvinus.WPF.Modules.Extensions;
    using Corvinus.WPF.Modules.UI;
    using Corvinus.WPF.Presentation.Services;
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
        /// Adds Views.
        /// </summary>
        /// <param name="services">The current instance of <see cref="IServiceCollection"/>.</param>
        /// <param name="modulePath">Optional string pointing to path for view module libraries.</param>
        /// <returns>The configured instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddViews(this IServiceCollection services, string modulePath = "")
        {
            List<Type> types = Assembly.GetCallingAssembly().GetTypes().Where(x => x.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IModuleView))).ToList();
            PageNavigationService navigationService = new ();

            foreach (Type type in types)
            {
                if (type.Name.EndsWith("View"))
                {
                    navigationService.AddView(type.Name, type);
                }

                services.AddSingleton(type);
            }

            if (!string.IsNullOrEmpty(modulePath))
            {
                services.AddModuleViews(AppContext.BaseDirectory + modulePath, navigationService);
            }

            services.AddSingleton<PageNavigationService>(navigationService);

            return services;
        }
    }
}
