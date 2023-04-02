using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class SubscribeMailManager:ISubscribeMailService
    {
        ISubscribeMailDal _subscribeMailDal;

        public SubscribeMailManager(ISubscribeMailDal subscribeMailDal)
        {
            _subscribeMailDal = subscribeMailDal;
        }

        public SubscribeMail GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<SubscribeMail> GetList()
        {
            throw new System.NotImplementedException();
        }

        public void TAdd(SubscribeMail entity)
        {
            _subscribeMailDal.Insert(entity);
        }

        public void TDelete(SubscribeMail entity)
        {
            throw new System.NotImplementedException();
        }

        public void TUpdate(SubscribeMail entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
