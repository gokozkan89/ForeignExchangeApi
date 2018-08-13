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
        public CurrencyController(ICurrencyService currencyServices)
        {
            this.currencyServices = currencyServices;           
        }
        
        [HttpGet("{Code}", Name="GetCurrency")]
        public ActionResult<Currency> GetCurrency(string Code)
        {
            return currencyServices.GetCurrency(Code);
        }
    }
}
        
    
        

