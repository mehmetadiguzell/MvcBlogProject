using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Security.Policy;

namespace BusinessLayer.Concrete
{
    public class CategoryManager:ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public void StatusChangeTrue(int id)
        {
            var model = _categoryDal.GetById(id);
            model.CataStatus = true;
           _categoryDal.Update(model);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }


        public void TAdd(Category entity)
        {
            _categoryDal.Insert(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryDal.Delete(entity);
        }

        public void TUpdate(Category entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
