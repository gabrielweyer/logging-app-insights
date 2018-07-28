using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logging.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddConfigurableApplicationInsightsTelemetry(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationInsightsTelemetry(options =>
            {
                var applicationVersion = configuration["ApplicationInsights:ApplicationVersion"];

                if (!string.IsNullOrWhiteSpace(applicationVersion))
                {
                    options.ApplicationVersion = applicationVersion;
                }

                var enableAdaptiveSamplingFromConfig = configuration["ApplicationInsights:EnableAdaptiveSampling"];

                if (bool.TryParse(enableAdaptiveSamplingFromConfig, out var enableAdaptiveSampling))
                {
                    options.EnableAdaptiveSampling = enableAdaptiveSampling;
                }

                var instrumentationKey = configuration["ApplicationInsights:InstrumentationKey"];

                if (!string.IsNullOrWhiteSpace(instrumentationKey))
                {
                    options.InstrumentationKey = instrumentationKey;
                }

                var developerModeFromConfig = configuration["ApplicationInsights:TelemetryChannel:DeveloperMode"];

                if (bool.TryParse(developerModeFromConfig, out var developerMode))
                {
                    options.DeveloperMode = developerMode;
                }
            });
        }
    }
}