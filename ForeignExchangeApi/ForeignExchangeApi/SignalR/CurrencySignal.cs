using ForeignExchangeApi.Controllers;
using ForeignExchangeApi.Models;
using ForeignExchangeApi.Services;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.SignalR
{
    public class CurrencySignal : Hub
    {
        private readonly IHttpClientServices currencyServices;
        public CurrencySignal(IHttpClientServices currencyServices) {
            this.currencyServices = currencyServices;
        }
        public async Task SendCurrenciesValue()
        {
            var result = currencyServices.GetList<Currency>("currencies/all/latest");
            await Clients.All.SendAsync("ReceiveCurrenciesValue",result);
        }

    }
}
