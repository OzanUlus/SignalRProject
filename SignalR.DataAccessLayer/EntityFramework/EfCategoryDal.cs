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
    public class EfCategoryDal : IGenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

        public int ActiveCategoryCount()
        {
            using var contex = new SignalRContext();
            var active = contex.Categories.Where(c => c.Status == true).Count();
            return active;
        }

        public int CategoryCount()
        {
            using var context = new SignalRContext();
            return context.Categories.Count();
        }

        public int PasiveCategoryCount()
        {
            using var contex = new SignalRContext();
            var pasive = contex.Categories.Where(c => c.Status == false).Count();
            return pasive;
        }
    }
}
