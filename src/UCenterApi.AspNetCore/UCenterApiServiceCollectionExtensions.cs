using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using UCenterApi.Api;
using UCenterApi.Client;
using Microsoft.Extensions.Configuration;

namespace UCenterApi.AspNetCore
{
    public static class UCenterApiServiceCollectionExtensions
    {
        public static IServiceCollection AddUCenterApi<TUcApi>(
            this IServiceCollection services, IConfiguration configuration)
            where TUcApi : BaseUcApi
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            UCenterApiOptions options = new UCenterApiOptions();

            configuration.GetSection("UCenterApi").Bind(options);

            services.AddSingleton(typeof(UCenterApiOptions), options);
            services.AddSingleton<IUcConfig>(options);

            services.AddScoped<UcUtility>();
            services.AddTransient<UcClient>();
            services.AddTransient<IUcClient, UcClient>();
            services.AddTransient<IUcApi, TUcApi>();


            return services;
        }
    }
}
