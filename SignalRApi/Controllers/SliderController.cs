using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;
        private readonly IMapper _mapper;

        public SliderController( IMapper mapper, ISliderService sliderService)
        {
            
            _mapper = mapper;
            _sliderService = sliderService;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var datas = _mapper.Map<List<ResultFeatureDto>>(_sliderService.TGetListAll());
            return Ok(datas);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var slider = _mapper.Map<Slider>(createFeatureDto);
            _sliderService.TAdd(slider);
            return Ok("Özellik bilgisi eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteFeature(int id)
        {
            var data = _sliderService.TGetById(id);
            _sliderService.TDelete(data);
            return Ok("Özellik bilgisi silindi");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var slider = _mapper.Map<Slider>(updateFeatureDto);
            _sliderService.TUpdate(slider); 
            return Ok("Özellik bilgisi güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var data = _sliderService.TGetById(id);
            return Ok(data);
        }
    }
}
