using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Models
{
    public class CurrencyDaily
    {
        [JsonProperty("selling")]
        public double Selling { get; set; }
        [JsonProperty("update_date")]
        public long UpdateDate { get; set; }
    }
}
