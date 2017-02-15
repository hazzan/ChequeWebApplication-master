using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeServerEntityFramework.Repository;
using ChequeServerEntityFramework.Entities;

namespace ChequeServerEntityFramework
{
    public class UnitOfWorks : IUnitOfWork, IDisposable
    {
        #region properties
        private IConfigurationDataContext ObjectContext;
        private bool disposed = false;
        private IRepository<BillingInformation> billingInformationRepository;
        private IRepository<MenuItem> menuItemRepository; 
        #endregion

        public UnitOfWorks()
        {
            this.ObjectContext = new ChequeContext();
        }

        public Repository.IRepository<BillingInformation> BillingInformationRepository
        {
            get 
            {
                if (this.billingInformationRepository == null)
                {
                    this.billingInformationRepository = new RepositoryBase<BillingInformation>(this.ObjectContext);
                }
                return this.billingInformationRepository;
            }
        }

        public Repository.IRepository<MenuItem> MenuItemRepository
        {
            get
            {
                if (this.menuItemRepository == null)
                {
                    this.menuItemRepository = new RepositoryBase<MenuItem>(this.ObjectContext);
                }
                return this.menuItemRepository;
            }
        }

        public void CommitChanges()
        {
            try
            {
                this.ObjectContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public virtual void Dispose(bool disposing)
        {
            // Do this only if the object has not been disposed before.
            if (!disposed)
            {
                if (disposing)
                {
                    // Clean up the services.
                    ((ChequeContext)this.ObjectContext).Dispose();
                }
            }
            disposed = true;
        }
    }
}
