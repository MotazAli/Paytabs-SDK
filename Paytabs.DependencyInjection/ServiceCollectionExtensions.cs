// Copyright (c) Motaz Ali, 2022. All rights reserved.
// Licensed under the Apache 2.0 license.
// See the LICENSE.txt file in the project root for full license information.

using Microsoft.Extensions.DependencyInjection;
using Paytabs.SDK;
using Paytabs.SDK.Interfaces;
using Paytabs.SDK.Models;
using Paytabs.SDK.Utilities;

namespace Paytabs.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>Adds services required for using paymob cash in.</summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="config">The action used to configure <see cref="PaytabsConfig"/>.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddPaytabs(this IServiceCollection services, Action<PaytabsConfig> config) 
        {

            if (services == null) throw new Exception("Service Collection should be provided");
            if (config == null) throw new Exception("PaytabsConfig should be provided");

            services.AddSingleton<PaytabsConfig>()
                .PostConfigure(config);
            services.AddSingleton<HttpService>()
                .AddHttpClient<HttpService>();

            services.AddScoped<IPaytabsTransaction, PaytabsTransaction>();
            return services;
        }
    }
}