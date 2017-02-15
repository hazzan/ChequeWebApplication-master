using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using ChequeConsumer.Dtos;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using ChequeBusinessData.Entity;
using ChequeConsumer.Interface;

namespace ChequeConsumer
{
    public class SOAPServiceMenuItemConsumer : ISOAPServiceMenuItemConsumer
    {
        public List<MenuItemDto> LoadMenuItemUsingSoapService()
        {
            ChequeSoapService.ChequeSOAPService ChequeSoap = new ChequeSoapService.ChequeSOAPService();
            string jsonMenu = ChequeSoap.GetAllMenuItems();
            List<MenuItemDto> deserializedMenuItem = new List<MenuItemDto>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<MenuItemDto>));
            using (TextReader reader = new StringReader(jsonMenu))
            {
                deserializedMenuItem = (List<MenuItemDto>)serializer.Deserialize(reader);
            }
            return deserializedMenuItem ?? new List<MenuItemDto>();
        }

        public List<MenuItemDto> LoadMenuItemListUsingSoapService() 
        {
            ChequeSoapService.ChequeSOAPService ChequeSoap = new ChequeSoapService.ChequeSOAPService();
            List<MenuItemDto> listMenuDto = new List<MenuItemDto>();
            var deserializedMenuItem = ChequeSoap.GetAllMenuItemsList();

            foreach (var item in deserializedMenuItem)
            {
                var menuItem = new MenuItemDto()
                {
                    Id = item.Id,
                    MENUNAME = item.MenuName,
                    MENUDESCRIPTION = item.MenuDescription,
                    Price = item.Price,
                    MENUCATEGORY = item.Category

                };

                listMenuDto.Add(menuItem);

            }
            return listMenuDto ?? new List<MenuItemDto>();
            
        }

        public string SaveMenuItemBySoap(List<BillingInformationDto> listBillingDto, DateTime chequeDate, string chequeNo)
        {
            ChequeSoapService.BillingInformation billInfo = new ChequeSoapService.BillingInformation();
            List<ChequeSoapService.MenuItem> listMenuItem = new List<ChequeSoapService.MenuItem>();
            ChequeSoapService.ChequeSOAPService ChequeSoap = new ChequeSoapService.ChequeSOAPService();
            billInfo.ChequeDate = chequeDate;
            billInfo.ChequeNo = chequeNo;
            try
            {
                foreach (var item in listBillingDto)
                {
                    ChequeSoapService.MenuItem menuItem = new ChequeSoapService.MenuItem()
                    {
                        Id = item.MenuID,
                        Category = item.Category,
                        Price = item.Price
                    };

                    listMenuItem.Add(menuItem);
                }
                billInfo.MenuItems = listMenuItem.ToArray();
                return ChequeSoap.SaveMenuItemBySaop(billInfo); 

            }
            catch (Exception)
            {

                throw;
            }
            return string.Empty;
        }

    }
}
