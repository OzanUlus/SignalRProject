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
    public class EfOrderDal : IGenericRepository<Order>, IOrderDal
    {
        public EfOrderDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            var ActiveOrder = context.Orders.Where(o => o.Ddescription == "Müşteri Masada").Count();
            return ActiveOrder;
        }

        public decimal LastOrderPrice()
        {
            using var context = new SignalRContext();
            var lastPrice = context.Orders.OrderByDescending(o => o.Id).Take(1)
                .Select(o => o.TotalPrice).FirstOrDefault();
            return lastPrice;
        }

        public int TotalOrderCount()
        {
            using var context = new SignalRContext();
            var orderCount = context.Orders.Count();
            return orderCount;
        }
    }
}
