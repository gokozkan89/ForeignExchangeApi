using AutoMapper;
using ForeignExchangeApi.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Services {
    public class CurrencyServices : ICurrencyService {
        private readonly IHttpClientService httpClientService;
        private readonly IMapper mapper;
        private readonly IMemoryCache memoryCache;

        public CurrencyServices(IHttpClientService httpClientService, IMapper mapper, IMemoryCache memoryCache)
        {
            this.httpClientService = httpClientService;
            this.mapper = mapper;
            this.memoryCache = memoryCache;
        }

        public List<CurrencyModel> GetCurrenciesFromCache(RequestModel requestModel)
        {
            
            var list =  memoryCache.GetOrCreate("Currencies",entry => {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);
                return LoadCurrenciesFromHttp();
            });
            return list.Where(x => requestModel.Codes.Contains(x.Code)).ToList();           
        }
        private List<CurrencyModel> LoadCurrenciesFromHttp()
        {
            var currencies = httpClientService.GetList<Currency>();
            return mapper.Map<List<CurrencyModel>>(currencies); ;
        }
       
    }
}
