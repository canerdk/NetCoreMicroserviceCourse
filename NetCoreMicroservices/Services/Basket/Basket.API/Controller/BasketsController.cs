using Basket.API.Dtos;
using Basket.API.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Services;
using System.Threading.Tasks;

namespace Basket.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ISharedIdentityService _sharedIdentityService;

        public BasketsController(IBasketService basketService, ISharedIdentityService sharedIdentityService)
        {
            _basketService = basketService;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasket()
        {
            return Ok(await _basketService.GetBasket(_sharedIdentityService.GetUserId));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrUpdateBasket(BasketDto basketDto)
        {
            return Ok(await _basketService.SaveOrUpdate(basketDto));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket()
        {
            return Ok(await _basketService.Delete(_sharedIdentityService.GetUserId));
        }
    }
}
