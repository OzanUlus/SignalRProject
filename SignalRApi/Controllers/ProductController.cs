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

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                Description = createProductDto.Description,
                ImageUrl = createProductDto.ImageUrl,
                Name = createProductDto.Name,
                Price = createProductDto.Price,
                Status =createProductDto.Status,
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
                CategoryId= updateProductDto.CategoryId,
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
