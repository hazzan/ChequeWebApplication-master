using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeBusinessData.Entity;

namespace ChequeBusinessData
{
    public class ChequeInformationConsum : IChequeInformationConsum
    {
        public List<MenuItem> SoapPopulateMenuItemList()
        {
            var listMenuItem = ChequeDataService.loadMenuItem();
            return listMenuItem;
        }


        public string SoapSaveBilling(BillingInformation menuitem)
        {
            return ChequeDataService.saveBillingItem(menuitem);
        }

        public List<MenuItem> RestPopulateMenuItem()
        {
            var listMenuItem = ChequeDataService.loadMenuItem();
            return listMenuItem;
        }

        public string RestSaveBilling(BillingInformation menuitem)
        {
            return ChequeDataService.saveBillingItem(menuitem);  
        }
    }
}
