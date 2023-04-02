﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        List<T> List(Expression<Func<T, bool>> filter);

        T Find(Expression<Func<T, bool>> filter);
    }
}
