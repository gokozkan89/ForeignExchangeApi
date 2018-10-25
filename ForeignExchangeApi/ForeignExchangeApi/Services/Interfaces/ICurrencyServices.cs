using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Services {
    public interface ICurrencyServices {
        T GetCurrency<T>(string endPoint);
        List<T> GetCurrencyList<T>(string endPoint);
    }
}
