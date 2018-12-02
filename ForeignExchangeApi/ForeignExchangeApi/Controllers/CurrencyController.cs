using FluentScheduler;
using ForeignExchangeApi.Models;
using ForeignExchangeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ForeignExchangeApi.Controllers {
    [Route("api/v1")]
    [ApiController]
    public class CurrencyController : Controller {
        private readonly ICurrencyService currencyServices;

        public CurrencyController(ICurrencyService currencyServices)
        {
            this.currencyServices = currencyServices;
        }
        [Route("currencies")]
        [HttpPost]
        public JsonResult GetCurrencies(RequestModel request)
        {
            return Json(currencyServices.GetCurrenciesFromCache(request));
        }
    }
}




