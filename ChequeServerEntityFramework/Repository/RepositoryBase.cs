using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Reflection;

namespace ChequeServerEntityFramework.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private IConfigurationDataContext chequeContext;
        public RepositoryBase(IConfigurationDataContext BaseContext)
        {
            this.chequeContext = BaseContext;
        }

        #region Public Methods
        public T Insert(T entity)
        {
            try
            {
                IDbSet<T> set = this.GetDbSet(typeof(T)).GetValue(this.chequeContext, null) as IDbSet<T>;
                set.Add(entity);
                return entity;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public T Update(T entity)
        {
            try
            {
                IDbSet<T> set = this.GetDbSet(typeof(T)).GetValue(this.chequeContext, null) as IDbSet<T>;
                set.Attach(entity);
                this.chequeContext.Entry(entity).State = EntityState.Modified;
                return entity;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                IDbSet<T> set = this.GetDbSet(typeof(T)).GetValue(this.chequeContext, null) as IDbSet<T>;
                DbEntityEntry<T> entry = this.chequeContext.Entry(entity);
                if (entry != null)
                {
                    entry.State = EntityState.Deleted;
                }
                else
                {
                    set.Attach(entity);
                }
                this.chequeContext.Entry(entity).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public T GetById(object Id)
        {
            try
            {
                IDbSet<T> set = this.GetDbSet(typeof(T)).GetValue(this.chequeContext, null) as IDbSet<T>;
                return set.Find(Id);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<T> GetAll()
        {
            try
            {
                PropertyInfo property = this.GetDbSet(typeof(T));
                IDbSet<T> set = property.GetValue(this.chequeContext, null) as IDbSet<T>;
                return set.ToList<T>();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> whereClause)
        {
            try
            {
                return this.chequeContext.Set<T>().Where(whereClause).ToList<T>();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public T Single(System.Linq.Expressions.Expression<Func<T, bool>> whereClause)
        {
            try 
	        {
                return this.chequeContext.Set<T>().Where(whereClause).SingleOrDefault();
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
           
        }

        public T First(System.Linq.Expressions.Expression<Func<T, bool>> whereClause)
        {
            try
            {
                return this.chequeContext.Set<T>().Where(whereClause).FirstOrDefault();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public IList<T> Select(string sqlQuery)
        {
            try
            {
                DbSqlQuery<T> queryResults = this.chequeContext.Set<T>().SqlQuery(sqlQuery);
                return queryResults.ToList<T>();

            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
        #endregion

        #region Private Methods
        private PropertyInfo GetDbSet(Type type)
        {
            var properties = this.chequeContext.GetType().GetProperties().Where(item => item.PropertyType.Equals(typeof(IDbSet<>).MakeGenericType(type)));
            return properties.First();
        }
        #endregion
    }
}
