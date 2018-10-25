using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Services {
    public interface IHttpClientServices {
        T Get<T>(string endPointName);
        List<T> GetList<T>(string endPointName);
    }
}
