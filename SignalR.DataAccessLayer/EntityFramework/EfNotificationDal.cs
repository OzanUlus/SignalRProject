using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : IGenericRepository<Notification> , INotificationDal
    {
        public EfNotificationDal(SignalRContext context) : base(context)
        {
        }

        public List<Notification> GetAllNotificationByFAlse()
        {
            using var context = new SignalRContext();
            var datas = context.Notifications.Where(n => n.Status == false).ToList();
            return datas;
        }

        public int NotifacationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            var datas = context.Notifications.Where(n => n.Status == false).Count();
            return datas;
        }

        public void NotificationStatusChangeToFalse(int id)
        {
            using var context = new SignalRContext();
            var data = context.Notifications.Find(id);
            data.Status = false;
            context.SaveChanges();
        }

        public void NotificationStatusChangeToTrue(int id)
        {
            using var context =new SignalRContext();
            var data = context.Notifications.Find(id);
            data.Status = true;
            context.SaveChanges();
        }
    }
}
