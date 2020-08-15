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
using UCenterApi.Common;

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

            string jsonStr = configuration.GetSection("UCenterApi").Value;
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;
            UCenterApiOptions options = JsonSerializer.Deserialize<UCenterApiOptions>(jsonStr, jsonSerializerOptions);

            services.AddSingleton(typeof(UCenterApiOptions), options);

            services.AddSingleton<IUcConfig, UCenterApiOptions>();

            services.AddScoped<UcUtility>();
            services.AddTransient<UcClient>();
            services.AddTransient<IUcClient, UcClient>();
            services.AddTransient<IUcApi, TUcApi>();


            return services;
        }
    }
}
