using ForeignExchangeApi.Extensions;
using ForeignExchangeApi.Handlers;
using ForeignExchangeApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ForeignExchangeApi {
    public class Startup {

        public void ConfigureServices(IServiceCollection services) {
            services.AddScoped<ICurrencyServices, CurrencyServices>();
            services.AddSingleton<IHttpClientServices, HttpClientService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddWebSocketManager();

        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider) {
            app.UseWebSockets();
            app.MapWebSocketManager("/currency", serviceProvider.GetService<CurrenciesHandler>());
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
