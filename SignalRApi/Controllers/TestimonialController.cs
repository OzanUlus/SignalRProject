using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(IMapper mapper, ITestimonialService testimonialService)
        {

            _mapper = mapper;
            _testimonialService = testimonialService;
        }
        [HttpGet]
        public IActionResult TestimonialList()
        {
            var datas = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
            return Ok(datas);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreatetestimonialDto createtestimonialDto)
        {
            _testimonialService.TAdd(new Testimonial()
            {
                Name = createtestimonialDto.Name,
                ImageUrl = createtestimonialDto.ImageUrl,
                Status = createtestimonialDto.Status,
                Comment = createtestimonialDto.Comment,
                Title = createtestimonialDto.Title,
                

            });
            return Ok("Testimonial eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var data = _testimonialService.TGetById(id);
            _testimonialService.TDelete(data);
            return Ok("Testimonial silindi");
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            _testimonialService.TUpdate(new Testimonial()
            {
                Name = updateTestimonialDto.Name,
                ImageUrl = updateTestimonialDto.ImageUrl,
                Status = updateTestimonialDto.Status,
                Comment = updateTestimonialDto.Comment,
                Title = updateTestimonialDto.Title,
                Id = updateTestimonialDto.Id

            });
            return Ok("Testimonial güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var data = _testimonialService.TGetById(id);
            return Ok(data);
        }
    }
}
