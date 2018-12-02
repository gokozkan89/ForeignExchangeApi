using AutoMapper;
using ForeignExchangeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeignExchangeApi
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Currency, CurrencyModel>();
            CreateMap<CurrencyModel, Currency>();
        }
    }
}
