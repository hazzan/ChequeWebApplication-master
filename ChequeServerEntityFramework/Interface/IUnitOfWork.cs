using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeServerEntityFramework.Repository;
using ChequeServerEntityFramework.Entities;

namespace ChequeServerEntityFramework
{
    public interface IUnitOfWork
    {
        IRepository<BillingInformation> BillingInformationRepository { get; } 

        IRepository<MenuItem> MenuItemRepository { get; }

        #region Public Methods

        /// <summary>
        /// Persist All the Changes to the DB
        /// </summary>
        void CommitChanges();

        #endregion
    }
}
