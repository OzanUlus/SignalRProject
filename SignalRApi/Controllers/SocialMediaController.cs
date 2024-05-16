using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var datas = _mapper.Map<List<ResultSocailMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(datas);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            _socialMediaService.TAdd(new SocialMedia()
            {
                Icon = createSocialMediaDto.Icon,
                Title = createSocialMediaDto.Title,
                Url = createSocialMediaDto.Url,

            });
            return Ok("SocialMedia eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var data = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(data);
            return Ok("SocialMedia silindi");
        }
        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocailMediaDto updateSocailMediaDto)
        {
            _socialMediaService.TUpdate(new SocialMedia()
            {
                Icon = updateSocailMediaDto.Icon,
                Title = updateSocailMediaDto.Title,
                Url = updateSocailMediaDto.Url,
                Id = updateSocailMediaDto.Id

            });
            return Ok("SocialMedia güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var data = _socialMediaService.TGetById(id);
            return Ok(data);
        }
    }
}
