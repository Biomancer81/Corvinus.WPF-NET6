// <copyright file="HostConfigurationExtensions.cs" company="Corvinus Collective">
// Copyright (c) Corvinus Collective. All rights reserved.
// </copyright>

namespace Corvinus.WPF.Modules.Extensions
{
    using Corvinus.WPF.Modules.UI;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Extension methods related to Host configuration.
    /// </summary>
    public static class HostConfigurationExtensions
    {
        /// <summary>
        /// Adds all views within the modules to the Host.
        /// </summary>
        /// <param name="services">The current instance of <see cref="IServiceCollection"/>.</param>
        /// <param name="modulesPath">The path where modules are to be loaded from.</param>
        /// <returns>The configured instance of <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddViewsWithModules(this IServiceCollection services, string modulesPath)
        {
            if (string.IsNullOrEmpty(modulesPath))
            {
                return services;
            }
            else
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(modulesPath);
                if (Directory.Exists(modulesPath))
                {
                    foreach (FileInfo file in directoryInfo.GetFiles("*.dll"))
                    {
                        Assembly assembly = Assembly.LoadFile(file.FullName);
                        var moduleViewModels = assembly.GetTypes().Where(x => x.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IModuleViewModel)));
                        var moduleViews = assembly.GetTypes().Where(x => x.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IModuleView)));

                        foreach (Type viewModel in moduleViewModels)
                        {
                            services.AddSingleton(viewModel);
                        }

                        foreach (Type view in moduleViews)
                        {
                            services.AddSingleton(view);
                        }
                    }
                }
                else
                {
                    Directory.CreateDirectory(modulesPath);
                }

                return services;
            }
        }
    }
}
