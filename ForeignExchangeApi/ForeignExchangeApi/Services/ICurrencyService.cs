using ForeignExchangeApi.Models;
using System.Collections.Generic;

namespace ForeignExchangeApi.Services
{
    public interface ICurrencyService
    {
        Currency GetCurrency(string Code);
        List<Currency> GetAllCurrencies();
        void AddCurrency(Currency currency);
    }
}