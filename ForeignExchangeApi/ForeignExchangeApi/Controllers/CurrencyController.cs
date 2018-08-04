using ForeignExchangeApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController:ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly CurrencyContext currencyContext;
        private HttpReq httpReq = new HttpReq();
        public CurrencyController(CurrencyContext context)
        {
            currencyContext = context;            
        }

        [HttpGet("{code}")]
        public ActionResult<Currency> Get(string code)
        {
            var curreny = currencyContext.Currencies.Find(code);
            if (curreny==null)
            {
                return NotFound();
            }
            return curreny;
        }
    }

}
