using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeServerEntityFramework.Entities;

namespace ChequeServerEntityFramework.Interface
{
    public interface IChequeService 
    {
        List<MenuItem> LoadMenuItemByEF();
        string SaveBillInformationByEF(BillingInformation billingInfo);
    }
}
