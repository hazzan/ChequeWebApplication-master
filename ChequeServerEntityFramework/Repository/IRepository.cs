using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace ChequeServerEntityFramework.Repository
{
    public interface IRepository<T>
    {
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
        T GetById(object Id);
        IList<T> GetAll();
        IList<T> Find(Expression<Func<T,bool>> whereClause);
        T Single(Expression<Func<T,bool>> whereClause);
        T First(Expression<Func<T, bool>> whereClause);
        IList<T> Select(string sqlQuery);
    }
}
