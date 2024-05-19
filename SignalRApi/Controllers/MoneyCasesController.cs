using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoneyCasesController : ControllerBase
    {
        private readonly IMoneyCaseService _moneyCaseService;

        public MoneyCasesController(IMoneyCaseService moneyCaseService)
        {
            _moneyCaseService = moneyCaseService;
        }
        [HttpGet("TotalPriceMoneyCase")]
        public IActionResult TotalPriceMoneyCase() 
        {
            var totalPrice = _moneyCaseService.TTotalMoneyCaseAmount();
            return Ok(totalPrice);
        }
    }
    
}
