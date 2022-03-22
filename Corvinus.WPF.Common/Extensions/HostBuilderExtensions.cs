using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corvinus.WPF.Common.Extensions
{
    public static class HostBuilderExtensions
    {
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
