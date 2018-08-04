using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi.Models
{
    public class Currency
    {
        public int currenyId;
        public string name;
        public string full_name;
        public double buying;
        public double selling;
        public double change_rate;
        public string update_date;
        public string code;
    }
}



