using Logging.Downstream.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Logging.Downstream.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<RequestLoggingMiddleware>();

            return builder;
        }
    }
}