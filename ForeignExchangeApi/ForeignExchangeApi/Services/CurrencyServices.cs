using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Services {
    public class CurrencyServices : ICurrencyServices {
        private readonly HttpClientService httpClientService;
        public CurrencyServices(HttpClientService httpClientService) {
            this.httpClientService = httpClientService;
        }
        public T GetCurrency<T>(string endPoint) {
            return httpClientService.Get<T>(endPoint);
        }
        public List<T>GetCurrencyList<T>(string endPoint) {
            return httpClientService.GetList<T>(endPoint);
        }
    }
}
