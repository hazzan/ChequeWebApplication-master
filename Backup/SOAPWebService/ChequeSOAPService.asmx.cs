using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ChequeBusinessData;
using System.Web.Script.Serialization;
using System.Text;
using ChequeBusinessData.Entity;
using System.Xml.Serialization;

namespace ChequeSOAPWebService
{
    /// <summary>
    /// Summary description for ChequeSOAPService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ChequeSOAPService : System.Web.Services.WebService
    {

        [WebMethod]
        public string GetAllMenuItems() 
        {
            var menuItems = GetChequeInformationConsum().SoapPopulateMenuItem();
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(menuItems.GetType());
            serializer.Serialize(stringwriter, menuItems);
            return stringwriter.ToString();
        }

        public IChequeInformationConsum GetChequeInformationConsum()
        {
            return new ChequeInformationConsum();
        }
    }
}
