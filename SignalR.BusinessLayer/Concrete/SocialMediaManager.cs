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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socailMediaDal;

        public SocialMediaManager(ISocialMediaDal socailMediaDal)
        {
            _socailMediaDal = socailMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _socailMediaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _socailMediaDal.Delete(entity);
        }

        public SocialMedia TGetById(int id)
        {
          return _socailMediaDal.GetById(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socailMediaDal.GetListAll();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socailMediaDal.Update(entity);
        }
    }
}
