using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using ChequeBusinessData.Entity;

namespace ChequeRESTService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRESTChequeService" in both code and config file together.
    [ServiceContract]
    public interface IRESTChequeService
    {
        [OperationContract]
        [WebInvoke(ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, Method = "POST", UriTemplate = "/SaveMenuItem")]
        void SaveMenuItem(List<BillingInformation> listBillingInfo);
        [OperationContract]
        [WebInvoke(Method="GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle=WebMessageBodyStyle.Wrapped, UriTemplate = "/MenuItem")]
        string MenuItem(); 
    }
}
