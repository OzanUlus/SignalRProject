using Microsoft.EntityFrameworkCore;
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
    public class EfProductDal : IGenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var contex = new SignalRContext();
            var datas = contex.Products.Include(p =>p.Category).ToList();
            return datas;
        }

        public decimal HamburgerPriceAvg()
        {
            var contex = new SignalRContext();
            return contex.Products.Where(p => p.CategoryId == (contex.Categories.Where(c => c.Name == "Hamburger")
            .Select(c => c.Id).FirstOrDefault())).Average(p => p.Price);
        }

        public int ProductCount()
        {
            using var contex = new SignalRContext();
            return contex.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            using var context = new SignalRContext();
            var count = context.Products.Where(p => p.CategoryId == (context.Categories
            .Where(c => c.Name == "İçecek").Select(z => z.Id).FirstOrDefault())).Count();
            return count;

        }

        public int ProductCountByCategoryNameHamburger()
        {
            using var context = new SignalRContext();
            var count = context.Products.Where(p => p.CategoryId == (context.Categories
            .Where(c => c.Name =="Hamburger").Select(z => z.Id).FirstOrDefault())).Count();
            return count;
        }

        public string ProductNameByMaxPrice()
        {
            using var contex = new SignalRContext();
            var maxName = contex.Products.Where(p => p.Price == (contex.Products.Max(p => p.Price)))
                .Select(p => p.Name).FirstOrDefault();
            return maxName;
        }

        public string ProductNameByMinPrice()
        {
            using var contex = new SignalRContext();
            var minName = contex.Products.Where(p => p.Price == (contex.Products.Min(p => p.Price)))
                .Select(p => p.Name).FirstOrDefault();
            return minName;
        }

        public decimal ProductPriceAvg()
        {
            using var context = new SignalRContext();

            return context.Products.Average(p => p.Price);
            
        }

       
    }
}
