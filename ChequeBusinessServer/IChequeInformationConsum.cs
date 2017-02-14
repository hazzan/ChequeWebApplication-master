using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeBusinessData.Entity;

namespace ChequeBusinessData 
{
    public interface IChequeInformationConsum
    {
        List<MenuItem> SoapPopulateMenuItemList();
        string SoapSaveBilling(BillingInformation billInfo);
        List<MenuItem> RestPopulateMenuItem();
        string RestSaveBilling(BillingInformation billInfo); 
    }
}
