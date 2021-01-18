using AutoMapper;
using MenuApplication.Core.Models;
using MenuApplication.Core.Services;
using MenuApplication.Mapping;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;
        private readonly IMapper mapper;
        public PizzaController(IPizzaService pizzaService, IMapper mapper)
        {
            this.mapper = mapper;
            this.pizzaService = pizzaService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<PizzaResource>>> GetPizzas()
        {
            var pizzas = await pizzaService.GetPizzas();
            var pizzaResource = mapper.Map<IEnumerable<Pizza>, IEnumerable<PizzaResource>>(pizzas);

            return Ok(pizzaResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PizzaResource>> GetPizza(int id)
        {
            var pizza = await pizzaService.Getpizza(id);
            var pizzaResource = mapper.Map<Pizza, PizzaResource>(pizza);

            return Ok(pizzaResource);
        }
    }
}
