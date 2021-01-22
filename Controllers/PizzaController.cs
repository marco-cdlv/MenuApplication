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

        [HttpPost("")]
        public async Task<ActionResult<PizzaResource>> AddPizza([FromBody] SavePizzaResource savePizzatResource)
        {
            var pizzaToCreate = mapper.Map<SavePizzaResource, Pizza>(savePizzatResource);
            var newPizza = await pizzaService.AddPizza(pizzaToCreate);
            var pizza = await pizzaService.Getpizza(newPizza.PizzaId);
            var pizzaResource = mapper.Map<Pizza, PizzaResource>(pizza);
            return Ok(pizzaResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id)
        {
            var pizza = await pizzaService.Getpizza(id);

            await pizzaService.DeletePizza(pizza);

            return NoContent();
        }

        [HttpDelete("{id}/{toppingId}")]
        public async Task<IActionResult> DeleteToppingFromPizza(int id, int toppingId)
        {            
            await pizzaService.DeleteToppingsFromPizzaAsync(id, toppingId);
            return NoContent();
        }

        [HttpPost("{pizzaId}")]
        public async Task<IActionResult> AddToppingToPizza(int pizzaId, [FromBody] SavePizzaDetailsResource savePizzaDetailsResource)
        {
            var pizzaDetailToCreate = mapper.Map<SavePizzaDetailsResource, PizzaDetails>(savePizzaDetailsResource);
            await pizzaService.AddToppingToPizza(pizzaId, pizzaDetailToCreate.ToppingId, pizzaDetailToCreate.ToppingQuantity);
            return Ok();
        }

        [HttpGet("{pizzaId}/Toppings")]
        public async Task<ActionResult<ToppingResource>> GetToppingsForPizza(int pizzaId)
        {
            var toppings = await pizzaService.GetToppingsForPizza(pizzaId);            
            var toppingResource = mapper.Map<IEnumerable<Topping>, IEnumerable<ToppingResource>>(toppings);

            return Ok(toppingResource);
        }
    }
}

