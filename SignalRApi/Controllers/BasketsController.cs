using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketsController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("GetBasketByMenuTableNumber")]
        public IActionResult GetBasketByMenuTableNumber(int id) 
        {
            var datas = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(datas);
        }
        [HttpGet("BasketListByMenuTableWithProductName")]
        public IActionResult BasketListByMenuTableWithProductName(int id)
        {
            using var context = new SignalRContext();
            var values = context.Baskets.Include(x => x.Product).Where(y => y.MenuTableId == id).Select(z => new ResultBAsketListWithProduct
            {
               Id= z.Id,
                Count = z.Count,
                MenuTableId = z.MenuTableId,
                Price = z.Price,
                ProductId = z.ProductId,
                TotalPrice = z.TotalPrice,
                ProductName = z.Product.Name,
            }).ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            //Bahçe 01 --> 45
            using var context = new SignalRContext();
            _basketService.TAdd(new Basket()
            {
                ProductId = createBasketDto.ProductId,
                Count = 1,
                MenuTableId = 4,
                Price = context.Products.Where(x => x.Id == createBasketDto.ProductId).Select(y => y.Price).FirstOrDefault(),
                TotalPrice = 0
            });
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetById(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}
