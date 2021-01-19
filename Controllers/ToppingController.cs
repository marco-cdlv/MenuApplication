using AutoMapper;
using MenuApplication.Core.Models;
using MenuApplication.Core.Services;
using MenuApplication.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToppingController : ControllerBase
    {
        private readonly IToppingService toppingService;
        private readonly IMapper mapper;
        public ToppingController(IToppingService toppingService, IMapper mapper)
        {
            this.mapper = mapper;
            this.toppingService = toppingService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<ToppingResource>>> GetToppings()
        {
            var toppings = await toppingService.GetToppings();
            var toppingResource = mapper.Map<IEnumerable<Topping>, IEnumerable<ToppingResource>>(toppings);

            return Ok(toppingResource);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToppingResource>> GetTopping(int id)
        {
            var topping = await toppingService.GetTopping(id);
            var toppingResource = mapper.Map<Topping, ToppingResource>(topping);

            return Ok(toppingResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopping(int id)
        {
            var topping = await toppingService.GetTopping(id);
            await toppingService.DeleteTopping(topping);

            return NoContent();
        }

        [HttpPost("")]
        public async Task<ActionResult<ToppingResource>> AddTopping([FromBody] SaveTopppingResource saveTopppingResource)
        {
            var toppingToCreate = mapper.Map<SaveTopppingResource, Topping>(saveTopppingResource);
            var newTopping = await toppingService.AddTopping(toppingToCreate);
            var topping = await toppingService.GetTopping(newTopping.ToppingId);
            var toppingResource = mapper.Map<Topping, ToppingResource>(topping);
            return Ok(toppingResource);
        }       
    }
}
