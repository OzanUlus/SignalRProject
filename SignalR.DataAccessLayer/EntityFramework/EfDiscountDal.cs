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
    public class EfDiscountDal : IGenericRepository<Discount>, IDiscountDal
    {
        public EfDiscountDal(SignalRContext context) : base(context)
        {
        }

        public void ChangeStatusFalse(int id)
        {
            using var contex = new SignalRContext();
            var data = contex.Discounts.Find(id);
            data.Status = false;
            contex.SaveChanges();
        }

        public void ChangeStatusTrue(int id)
        {
            using var contex = new SignalRContext();
            var data = contex.Discounts.Find(id);
            data.Status = true;
            contex.SaveChanges();
        }

        public List<Discount> GetListStatusTrue()
        {
            using var context = new SignalRContext();
            var datas = context.Discounts.Where(x => x.Status == true).ToList();
            return datas;
        }
    }
}
