using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IMessageService messageService, IMapper mapper )
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetListMessage() 
        {
          var datas = _messageService.TGetListAll();
            return Ok(datas);
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto) 
        {
            var message = _mapper.Map<Message>(createMessageDto);
            message.Status = false;
            message.MessageDate = DateTime.Now;
            _messageService.TAdd(message);
            return Ok("Mesaj Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id) 
        {
          var data = _messageService.TGetById(id);
            _messageService.TDelete(data);
            return Ok("Mesaj Silindi");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto) 
        {
            var message = _mapper.Map<Message>(updateMessageDto);
            message.Status = false;
            message.MessageDate = DateTime.Now;
            _messageService.TUpdate(message);
            return Ok("Mesaj Güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id) 
        {
            var data = _messageService.TGetById(id);
            return Ok(data);
        }

    }
}
