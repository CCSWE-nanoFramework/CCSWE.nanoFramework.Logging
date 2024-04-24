using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CCSWE.nanoFramework.Logging
{
    /// <summary>
    /// Extension methods for <see cref="IServiceCollection"/>.
    /// </summary>
    public static class Bootstrapper
    {
        /// <summary>
        /// Adds an <see cref="DebugLogger"/> to the <see cref="IServiceCollection"/>.
        /// </summary>
        public static IServiceCollection AddLogging(this IServiceCollection services, ConfigureLoggerOptions? configureOptions = null)
        {
            var options = new LoggerOptions();
            if (configureOptions is null)
            {
#if DEBUG
                options.MinLogLevel = LogLevel.Debug;
#else
                options.MinLogLevel = LogLevel.Warning;
#endif
            }

            configureOptions?.Invoke(options);

            services.AddSingleton(typeof(ILogger), typeof(DebugLogger));
            services.AddSingleton(typeof(LoggerOptions), options);

            LoggerFormatter.Initialize();

            return services;
        }
    }
}
