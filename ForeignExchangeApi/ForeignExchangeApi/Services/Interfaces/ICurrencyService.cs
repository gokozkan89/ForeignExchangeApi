using ForeignExchangeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Services {
    public interface ICurrencyService {
        List<CurrencyModel> GetCurrenciesFromCache(RequestModel requestModel);
    }
}
