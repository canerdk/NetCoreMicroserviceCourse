using Discount.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Services;
using System.Threading.Tasks;

namespace Discount.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly ISharedIdentityService _identityService;

        public DiscountsController(IDiscountService discountService, ISharedIdentityService identityService)
        {
            _discountService = discountService;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _discountService.GetAll());
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var discount = await _discountService.GetById(id);
            return Ok(discount);
        }

        [HttpGet("getbycode")]
        public async Task<IActionResult> GetByCode(string code)
        {
            var userId = _identityService.GetUserId;
            var discount = await _discountService.GetByCodeAndUserId(userId, code);

            return Ok(discount);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Models.Discount discount)
        {
            return Ok(await _discountService.Save(discount));
        }

        [HttpPut]
        public async Task<IActionResult> Update(Models.Discount discount)
        {
            return Ok(await _discountService.Update(discount));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _discountService.Delete(id));
        }
    }
}
