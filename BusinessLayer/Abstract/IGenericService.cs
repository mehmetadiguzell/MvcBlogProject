using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T>
    {
        List<T> GetList();
        void TAdd(T entity);
        T GetById(int id);
        void TDelete(T entity);
        void TUpdate(T entity);
    }
}
