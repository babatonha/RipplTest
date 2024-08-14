using Microsoft.AspNetCore.Mvc;
using Rippl.BusinessLayer.Interfaces.Services;
using Rippl.DataLayer.Models;

namespace Rippl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService; 
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("AddToCart")]
        public async Task<ActionResult> AddToCart([FromBody] Cart cart)
        {
            var response = await _cartService.AddToCart(cart);

            if(response.IsSuccessStatusCode)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }

        [HttpPost("Checkout")]
        public async Task<ActionResult> Checkout([FromBody] Cart cart)
        {
            var response = await _cartService.Checkout(cart);

            if (response.IsSuccessStatusCode)
            {
                return Ok(response);
            }

            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }
}
