using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public NotificationController(INotificationService notificationService, IMapper mapper)
        {
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet("ListNotification")]
        public IActionResult ListNotification()
        {
            var datas = _notificationService.TGetListAll();
            return Ok(datas);
        }
        [HttpGet("NotifacationCountByStatusFalse")]
        public IActionResult NotifacationCountByStatusFalse()
        {
            var data = _notificationService.NotifacationCountByStatusFalse();
            return Ok(data);
        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            var datas = _notificationService.TGetAllNotificationByFAlse();
            return Ok(datas);
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
        {
            var notification = _mapper.Map<Notification>(createNotificationDto);
            _notificationService.TAdd(notification);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id) 
        {
          var data = _notificationService.TGetById(id);
            _notificationService.TDelete(data);
            return Ok("Silme Başarılı");
        }
        [HttpPut()]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto) 
        {
            var notification = _mapper.Map<Notification>(updateNotificationDto);
            _notificationService.TUpdate(notification);
            return Ok("Güncelleme Başarılı");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var data = _notificationService.TGetById(id);
            return Ok(data);
        }
        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
             _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Güncelleme Yapıldı");
        }

    }
}
