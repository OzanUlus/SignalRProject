﻿using SignalR.DataAccessLayer.Abstract;
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

        public int NotifacationCountByStatusFalse()
        {
            using var context = new SignalRContext();
            var datas = context.Notifications.Where(n => n.Status == false).Count();
            return datas;
        }
    }
}
