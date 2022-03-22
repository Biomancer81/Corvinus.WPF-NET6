using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Corvinus.WPF.Common.Extensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddAppConfig<T>(this IServiceCollection services, IConfiguration configuration)
        {
            T appConfig = configuration.GetSection("ApplicationConfiguration").Get<T>();

            if(appConfig != null)
            {
                services.AddSingleton(typeof(T), appConfig);
            }

            return services;
        }
    }
}
