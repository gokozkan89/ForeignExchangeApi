﻿using System;
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

namespace ForeignExchangeApi
{
    public class Startup
    {
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICurrencyService, CurrencyService>();            
            services.AddScoped(typeof(HttpClientService));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app)
        {
           
            app.UseMvc();
        }
    }
}
