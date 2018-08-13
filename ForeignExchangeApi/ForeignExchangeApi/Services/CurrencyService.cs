using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForeignExchangeApi.Models;

namespace ForeignExchangeApi.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRequestService currencyRequestService;
        public CurrencyService(ICurrencyRequestService currencyRequestService)
        {
            this.currencyRequestService = currencyRequestService;
        }
        public List<Currency> GetAllCurrencies()
        {
            return null;
        }

        public void AddCurrency(Currency currency)
        {

        }

        public Currency GetCurrency(string Code)
        {
            var a = currencyRequestService.GetCurrency(Code);
            return null;
        }
    }
}
