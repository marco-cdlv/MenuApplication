using AutoMapper;
using MenuApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApplication.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Topping, ToppingResource>();
            CreateMap<Pizza, PizzaResource>();

            // Resource to Domain
            CreateMap<ToppingResource, Topping>();
            CreateMap<SaveTopppingResource, Topping>();
            CreateMap<PizzaResource, Pizza>();
            CreateMap<SavePizzaResource, Pizza>();
        }
    }
}
