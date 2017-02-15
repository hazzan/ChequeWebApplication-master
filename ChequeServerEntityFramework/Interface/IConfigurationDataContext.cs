using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeServerEntityFramework.Entities;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ChequeServerEntityFramework
{
    public interface IConfigurationDataContext
    {
        #region Entity Sets

        IDbSet<BillingInformation> BillingInformation { get; }
        IDbSet<MenuItem> MenuItem { get; }

        #endregion

        #region Public Methods
        
        DbEntityEntry<T> Entry<T>(T entity) where T : class;       
        DbSet<T> Set<T>() where T : class;       
        int SaveChanges();
        
        #endregion
    }
}
