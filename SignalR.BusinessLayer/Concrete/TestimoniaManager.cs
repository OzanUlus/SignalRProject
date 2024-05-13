using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class TestimoniaManager : ITestimonialService
    {
        private readonly ITestimonial _testimonial;

        public TestimoniaManager(ITestimonial testimonial)
        {
            _testimonial = testimonial;
        }

        public void TAdd(Testimonial entity)
        {
            _testimonial.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _testimonial.Delete(entity);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonial.GetById(id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _testimonial.GetListAll();
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonial.Update(entity);
        }
    }
}
