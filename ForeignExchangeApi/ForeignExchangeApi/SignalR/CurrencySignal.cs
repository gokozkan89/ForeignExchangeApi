using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.SignalR
{
    public class CurrencySignal : Hub
    {
        public async Task Send(string deneme)
        {
            await Clients.All.SendAsync("AllCurrency", deneme);
        }

    }
}
