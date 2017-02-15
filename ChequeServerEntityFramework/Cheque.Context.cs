using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using ChequeServerEntityFramework.Entities;

namespace ChequeServerEntityFramework
{
    public sealed class ChequeContext : DbContext, IConfigurationDataContext 
    {
        public ChequeContext()
            : base("name=ChequeDbEntities")
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        #region Private Variables
        private IDbSet<BillingInformation> billingInformation; 
        private IDbSet<MenuItem> menuItem;
        #endregion

        #region Public Methods
        public IDbSet<BillingInformation> BillingInformation
        {
            get 
            {
                if (this.billingInformation == null)
                {
                    this.billingInformation = this.Set<BillingInformation>();
                }
                return this.billingInformation;
            }
        }

        public IDbSet<MenuItem> MenuItem
        {
            get 
            {
                if (this.menuItem == null)
                {
                    this.menuItem = this.Set<MenuItem>();
                }
                return this.menuItem;
            }
        }
        #endregion

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public new void Dispose(bool dispose)
        {
            if (!dispose)
                if (dispose)
                    base.Dispose();
            dispose = true;
        }
    }
}
