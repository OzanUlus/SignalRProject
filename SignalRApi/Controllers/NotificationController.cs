using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.DataAccessLayer.Abstract;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationDal _notificationDal;

        public NotificationController(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }
        [HttpGet("ListNotification")]
        public IActionResult ListNotification() 
        {
            var datas = _notificationDal.GetListAll();
            return Ok(datas);   
        }
        [HttpGet("NotifacationCountByStatusFalse")]
        public IActionResult NotifacationCountByStatusFalse()
        {
          var data = _notificationDal.NotifacationCountByStatusFalse();
            return Ok(data);
        }
    }
}
