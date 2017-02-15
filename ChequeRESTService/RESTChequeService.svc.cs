using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChequeBusinessData;
using System.Web.Script.Serialization;
using ChequeBusinessData.Entity;
using ChequeServerEntityFramework.Interface;
using ChequeServerEntityFramework;

namespace ChequeRESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RESTChequeService" in code, svc and config file together.
    public class RESTChequeService : IRESTChequeService
    {
        public IChequeInformationConsum ChequeInformationConsum { get; set; }

        public string MenuItem()
        {
             var menuItem =  GetChequeInformationConsum().RestPopulateMenuItem();
             var jsonSerialiser = new JavaScriptSerializer();
             var munuItemJson = jsonSerialiser.Serialize(menuItem);
             return munuItemJson;
        }
        public void SaveMenuItem(ChequeBusinessData.Entity.BillingInformation listBillingInfo) 
        {
            GetChequeInformationConsum().RestSaveBilling(listBillingInfo);
        }

        public string MenuItemByEF()
        {
            try
            {
                var menuItemList = GetChequeService().LoadMenuItemByEF();
                var jsonSerialiser = new JavaScriptSerializer();
                var munuItemJson = jsonSerialiser.Serialize(menuItemList);
                return munuItemJson;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SaveMenuItemByEF(ChequeBusinessData.Entity.BillingInformation billingInfo)
        {
            ChequeServerEntityFramework.BillingInformation billInfo = new ChequeServerEntityFramework.BillingInformation();
            foreach (var item in billingInfo.MenuItems)
            {
                billInfo.ID = item.Id;
                billInfo.CATEGORY = item.Category;
                billInfo.MENUID = item.Id;
                billInfo.PRICE = item.Price;
                billInfo.CHEQUENO = billingInfo.ChequeNo;
                billInfo.CHEQUEDATE = billingInfo.ChequeDate;
                GetChequeService().SaveBillInformationByEF(billInfo);   
            }
        }

        #region Private Method
        private IChequeInformationConsum GetChequeInformationConsum()
        {
            return new ChequeInformationConsum();
        }

        private IChequeService GetChequeService()
        {
            return new ChequeService();
        }
        #endregion 
    }
}
