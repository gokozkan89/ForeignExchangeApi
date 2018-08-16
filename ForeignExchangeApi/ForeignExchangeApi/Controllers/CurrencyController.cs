using ForeignExchangeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ForeignExchangeApi.Services;

namespace ForeignExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController:ControllerBase
    {
        private readonly ICurrencyService currencyServices;
        private readonly HttpClientService httpClientService;
        public CurrencyController(ICurrencyService currencyServices,HttpClientService httpClientService)
        {
            this.currencyServices = currencyServices;
            this.httpClientService = httpClientService;
        }
        
        [HttpGet("{Code}/latest")]
        public ActionResult<Currency> LatestCurrency(string Code)
        {
            var request = string.Concat("currencies/", Code, "/latest");
            return httpClientService.Get<Currency>(request); 
        }
        [HttpGet("{Code}/daily")]
        public ActionResult<List<CurrencyDaily>> DailyCurrency(string Code)
        {
            var request = string.Concat("currencies/", Code, "/daily");
            return httpClientService.GetList<CurrencyDaily>(request);
        }
    }
}
        
    
        

