using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ForeignExchangeApi.Controllers;
using ForeignExchangeApi.Models;
using Newtonsoft.Json;

namespace ForeignExchangeApi.Services
{
    public class CurrencyRequestService : ICurrencyRequestService
    {
        

        public List<Currency> GetAllCurrency()
        {
            throw new NotImplementedException();
        }

        public async Task<Currency> GetCurrency(string Code)
        {
           return await CurrencyData(Code);
        }

        private async Task<Currency> CurrencyData(string Code)
        {
            Currency currency = new Currency();
            string baseUrl = "https://www.doviz.com/api/v1/currencies/"+Code+"/latest";
            using (HttpClient client = new HttpClient())
            {
                using(HttpResponseMessage res = await client.GetAsync(baseUrl))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        currency = JsonConvert.DeserializeObject<Currency>(data);
                        return currency;
                    }
                }
            }
                
        } 
    }
}
