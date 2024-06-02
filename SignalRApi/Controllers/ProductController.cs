using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var datas = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(datas);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var contex = new SignalRContext();
            var datas = contex.Products.Include(p => p.Category).Select(y => new ResultProductWithCategory()
            {
                CategoryName = y.Category.Name,
                Description = y.Description,
                ImageUrl = y.ImageUrl,
                Name = y.Name,
                Price = y.Price,
                Status = y.Status,
                Id = y.Id

            });
            return Ok(datas.ToList());
        }
        [HttpGet("ProductCountByHamburger")]
        public IActionResult ProductCountByHamburger()
        {
            var count = _productService.TProductCountByCategoryNameHamburger();
            return Ok(count);
        }
        [HttpGet("ProductPriceBySteakHamburger")]
        public IActionResult ProductPriceBySteakHamburger()
        {
            var count = _productService.TProductPriceBySteakHamburger();
            return Ok(count);
        }
        [HttpGet("ProductCountByDrink")]
        public IActionResult ProductCountByDrink()
        {
            var count = _productService.TProductCountByCategoryNameDrink();
            return Ok(count);
        }
        [HttpGet("TotalPriceByDrinkCategory")]
        public IActionResult TotalPriceByDrinkCategory()
        {
            var price = _productService.TTotalPriceByDrinkCategory();
            return Ok(price);
        }
        [HttpGet("TotalPriceBySaladCategory")]
        public IActionResult TotalPriceBySaladCategory()
        {
            var price = _productService.TTotalPriceBySaladCategory();
            return Ok(price);
        }
        [HttpGet("ProductCount")]
        public IActionResult ProductCount()
        {
            var count = _productService.TProductCount();
            return Ok(count);
        }
        [HttpGet("AvgProductPrice")]
        public IActionResult AvgProductPrice()
        {
            var count = _productService.TProductPriceAvg();
            return Ok(count);
        }
        [HttpGet("MaxProductName")]
        public IActionResult MaxProductName()
        {
            var count = _productService.TProductNameByMaxPrice();
            return Ok(count);
        }
        [HttpGet("MinProductName")]
        public IActionResult MinProductName()
        {
            var count = _productService.TProductNameByMinPrice();
            return Ok(count);
        }
        [HttpGet("HamburgerPriceAvg")]
        public IActionResult HamburgerPriceAvg()
        {
            var avgPrice = _productService.THamburgerPriceAvg();
            return Ok(avgPrice);
        }
        

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Status = createProductDto.Status,
                CategoryId = createProductDto.CategoryId,

            });
            return Ok("Product eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var data = _productService.TGetById(id);
            _productService.TDelete(data);
            return Ok("Product silindi");
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TUpdate(new Product()
            {
                Id = updateProductDto.Id,
                Description = updateProductDto.Description,
                ImageUrl = updateProductDto.ImageUrl,
                Name = updateProductDto.Name,
                Price = updateProductDto.Price,
                Status = updateProductDto.Status,
                CategoryId = updateProductDto.CategoryId,
            });
            return Ok("Product güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var data = _productService.TGetById(id);
            return Ok(data);
        }
    }
}
