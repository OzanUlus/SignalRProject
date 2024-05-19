using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]   
        public IActionResult CategoryList() 
        {
            var datas = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(datas);
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount() 
        {
          var count = _categoryService.TCategoryCount();
            return Ok(count);
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            var count = _categoryService.TActiveCategoryCount();
            return Ok(count);
        }
        [HttpGet("PassiveCategoryCount")]
        public IActionResult PassiveCategoryCount()
        {
            var count = _categoryService.TPasiveCategoryCount();
            return Ok(count);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto) 
        {
            _categoryService.TAdd(new Category() 
            {
             Name = createCategoryDto.Name,
             Status = true,
            });
            return Ok("Kategori eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id) 
        {
          var data = _categoryService.TGetById(id);
            _categoryService.TDelete(data);
            return Ok("Kategori silindi");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto) 
        {
            _categoryService.TUpdate(new Category()
            {
                Id = updateCategoryDto.Id,
                Name = updateCategoryDto.Name,
                Status = updateCategoryDto.Status,
            });
            return Ok("Kategori güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id) 
        {
            var data = _categoryService.TGetById(id);
            return Ok(data);
        }
    }
}
