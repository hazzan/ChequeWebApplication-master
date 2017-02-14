using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ChequeBusinessData;
using System.Web.Script.Serialization;
using ChequeBusinessData.Entity;

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
        public void SaveMenuItem(List<BillingInformation> listBillingInfo) 
        {
            GetChequeInformationConsum().RestSaveBilling(listBillingInfo);
        }

        public IChequeInformationConsum GetChequeInformationConsum()
        {
            return new ChequeInformationConsum();
        }

        
    }
}
