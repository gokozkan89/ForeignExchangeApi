using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForeignExchangeApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ForeignExchangeApi.Services;
using ForeignExchangeApi.SignalR;

namespace ForeignExchangeApi
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICurrencyServices,CurrencyServices>();
            services.AddScoped<IHttpClientServices,HttpClientService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(options => options.AddPolicy("CorsPolicy", builder => {
                builder
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:3902");
            }));
            services.AddSignalR();
           
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSignalR(routes => {
                routes.MapHub<CurrencySignal>("/currenciesValues");
            });
            app.UseCors("CorsPolicy");
            app.UseMvc();
        }
    }
}
