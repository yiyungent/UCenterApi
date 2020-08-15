using System;
using Microsoft.AspNetCore.Builder;

namespace UCenterApi.AspNetCore
{
    public static class UCenterApiMiddlewareExtensions
    {
        public static IApplicationBuilder UseUCenterApi(this IApplicationBuilder builder)
        {
            builder.MapWhen(m => m.Request.Path.StartsWithSegments("/api/UCenterApi", StringComparison.OrdinalIgnoreCase), app => app.UseMiddleware<UCenterApiMiddleware>());

            return builder;
        }
    }
}
