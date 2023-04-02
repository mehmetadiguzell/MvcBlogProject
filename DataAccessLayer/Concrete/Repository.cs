using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Concrete
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        DbSet<T> _object;
        public Repository()
        {
            _object = context.Set<T>();
        }
        public void Delete(T entity)
        {
            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> filter)
        {
            return _object.FirstOrDefault(filter);
        }

        public T GetById(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T entity)
        {
            var updateEntity = context.Entry(entity);
            updateEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            var updateEntity=context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges(); ; ;
        }
    }
}
