using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Models
{
    public class CurrencyModel
    {
        public string Name { get; set; }

        public double Buying { get; set; }

        public double Selling { get; set; }

        public double ChangeRate { get; set; }

        public string UpdateDate { get; set; }

        public string Code { get; set; }
    }
}
