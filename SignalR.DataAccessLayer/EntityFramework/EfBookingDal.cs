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
    public class EfBookingDal : IGenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

        public void BookingStatusApproved(int id)
        {
            using var contex = new SignalRContext();
            var data = contex.Bookings.Find(id);
            data.Description = "Rezervasyon Onaylandı";
            contex.SaveChanges();
            
            
        }

        public void BookingStatusCanceled(int id)
        {
            using var contex = new SignalRContext();
            var data = contex.Bookings.Find(id);
            data.Description = "Rezervasyon İptal Edildi";
            contex.SaveChanges();
        }
    }
}
