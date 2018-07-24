using Logging.Web.Middleware;
using Microsoft.AspNetCore.Builder;

namespace Logging.Web.Extensions
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