using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeServerEntityFramework.Interface;

namespace ChequeServerEntityFramework
{
    public class ChequeService : IChequeService
    {
        private IUnitOfWorkFactory unitOfWorkFactory;

        public ChequeService()
        {
            this.unitOfWorkFactory = new UnitOfWorkFactory();

        }

        public List<MenuItem> LoadMenuItemByEF()
        {
            try
            {
                IUnitOfWork unitOfWork = this.unitOfWorkFactory.CreateUnitOfWork();
                var menuItem = unitOfWork.MenuItemRepository.GetAll();
                return menuItem.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string SaveBillInformationByEF(BillingInformation billingInfo)
        {
            try
            {
                IUnitOfWork unitOfWork = this.unitOfWorkFactory.CreateUnitOfWork();
                unitOfWork.BillingInformationRepository.Insert(billingInfo);
                unitOfWork.CommitChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return string.Empty;
        }
    }
}
