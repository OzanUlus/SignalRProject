using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService discountService, IMapper mapper)
        {
            _discountService = discountService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult DiscountList()
        {
            var datas = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
            return Ok(datas);
        }

        [HttpPost]
        public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            
            _discountService.TAdd(new Discount()
            {
                Amount = createDiscountDto.Amount,
                Description = createDiscountDto.Description,
                ImageUrl = createDiscountDto.ImageUrl,
                Title = createDiscountDto.Title,
                Status = false,
            });
            return Ok("İndirim bilgisi eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDiscount(int id)
        {
            var data = _discountService.TGetById(id);
            _discountService.TDelete(data);
            return Ok("İndirim bilgisi silindi");
        }
        [HttpPut]
        public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            _discountService.TUpdate(new Discount()
            {
                Id = updateDiscountDto.Id,
                Amount = updateDiscountDto.Amount,
                Description = updateDiscountDto.Description,
                ImageUrl = updateDiscountDto.ImageUrl,
                Title = updateDiscountDto.Title,
                Status = false
            }); ;
            return Ok("İndirim bilgisi güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetDiscount(int id)
        {
            var data = _discountService.TGetById(id);
            return Ok(data);
        }
        [HttpGet("ChangeStatusTrue/{id}")]
        public IActionResult ChangeStatusTrue(int id)
        {
            _discountService.TChangeStatusTrue(id);
            return Ok("Status true");
        }
        [HttpGet("ChangeStatusFalse/{id}")]
        public IActionResult ChangeStatusFalse(int id)
        {
            _discountService.TChangeStatusFalse(id);
            return Ok("status false");
        }

    }
}
