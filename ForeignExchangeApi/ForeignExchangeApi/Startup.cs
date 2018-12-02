using AutoMapper;
using ForeignExchangeApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ForeignExchangeApi {
    public class Startup {

        public void ConfigureServices(IServiceCollection services) {
            services.AddAutoMapper();
            services.AddTransient<ICurrencyService, CurrencyServices>();
            services.AddSingleton<IHttpClientService, HttpClientService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider) {
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
