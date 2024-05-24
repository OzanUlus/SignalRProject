using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuTablesController : ControllerBase
    {
        private readonly IMenuTableService _menuTableService;
        private readonly IMapper _mapper;

        public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
        {
            _menuTableService = menuTableService;
            _mapper = mapper;
        }
        [HttpGet("MenuTableCount")]
        public IActionResult MenuTableCount()
        {
            var tableCount = _menuTableService.TMenuTableCount();
            return Ok(tableCount);
        }
        [HttpGet]
        public IActionResult MenuTableList()
        {
            var datas = _menuTableService.TGetListAll();
            return Ok(datas);
        }
        [HttpPost]
        public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto )
        {
            createMenuTableDto.Status = false;
            var menuTable = _mapper.Map<MenuTable>(createMenuTableDto);
            _menuTableService.TAdd(menuTable);
            return Ok("Masa eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMenuTable(int id)
        {
            var data = _menuTableService.TGetById(id);
            _menuTableService.TDelete(data);
            return Ok("Masa silindi");
        }
        [HttpPut]
        public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto )
        {
            var menuTable = _mapper.Map<MenuTable>(updateMenuTableDto);
            _menuTableService.TUpdate(menuTable);
            return Ok("Masa güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMenuTable(int id)
        {
            var data = _menuTableService.TGetById(id);
            return Ok(data);
        }
        
    }
}
