using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using ChequeConsumer.Dtos;
using ChequeBusinessData.Entity;
using System.Web.Script.Serialization;
using ChequeConsumer.Interface;

namespace ChequeConsumer
{
    public class MenuItemConsumer : IMenuItemConsumer
    {

        readonly string customerServiceUri = "http://localhost:59525/RESTChequeService.svc/REST{0}";
        public List<MenuItemDto> LoadMenuItem() 
        {
            WebClient RESTProxy = new WebClient();
            string jsonData = RESTProxy.DownloadString(new Uri(string.Format(customerServiceUri,"/MenuItem")));
            jsonData = jsonData.Replace(@"\", "");
            jsonData = jsonData.Substring(0, jsonData.Length - 2);
            if (jsonData.Length > 19)
            {
                jsonData = jsonData.Substring(19, jsonData.Length - 19);
            }
            var serializer = new JavaScriptSerializer();
            var objMenuItem = serializer.Deserialize<List<MenuItemDto>>(jsonData);
            return objMenuItem; 
        }

        public string InsertChequeInfoByRest(List<BillingInformationDto> listBillingDto, DateTime chequeDate, string chequeNo)   
        {
            BillingInformation billInfo = new BillingInformation();
            billInfo.ChequeDate = chequeDate;
            billInfo.ChequeNo = chequeNo;
            billInfo.MenuItems = new List<MenuItem>();
            try
            {
                foreach (var item in listBillingDto)
                {
                    MenuItem menuItem = new MenuItem() 
                    {
                        Id = item.MenuID,
                        Category = item.Category,
                        Price = item.Price
                    };

                    billInfo.MenuItems.Add(menuItem);
                }

                using (WebClient wc = new WebClient())
                {

                    MemoryStream ms = new MemoryStream();
                    DataContractJsonSerializer serializerToUplaod = new DataContractJsonSerializer(typeof(List<BillingInformation>));
                    serializerToUplaod.WriteObject(ms, billInfo);
                    wc.Headers["Content-type"] = "application/json";
                    wc.UploadData(string.Format(customerServiceUri, "/SaveMenuItem"), "POST", ms.ToArray());
                }
            
            }
            catch (Exception)
            {
                
                throw;
            }
            return "success";
        }
    }
}
