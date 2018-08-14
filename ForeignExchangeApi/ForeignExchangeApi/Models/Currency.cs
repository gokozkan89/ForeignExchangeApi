using ForeignExchangeApi.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Models
{
    public class Currency
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("full_name")]
        public string FullName { get; set; }

        [JsonProperty("buying")]
        public double Buying { get; set; }

        [JsonProperty("selling")]
        public double Selling { get; set; }

        [JsonProperty("change_rate")]
        public double ChangeRate { get; set; }

        [JsonProperty("update_date")]
        private long UpdateDateTic { get; set; }

        public DateTime UpdateDate
        {
            get
            {
                return UpdateDateTic.ToDateTime();
            }
        }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}



