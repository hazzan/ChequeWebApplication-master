using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeConsumer.Dtos;

namespace ChequeConsumer.Interface
{
    public interface ISOAPServiceMenuItemConsumer
    {
        List<MenuItemDto> LoadMenuItemUsingSoapService();
        List<MenuItemDto> LoadMenuItemListUsingSoapService();
        string SaveMenuItemBySoap(List<BillingInformationDto> listBillingDto, DateTime chequeDate, string chequeNo);
    }
}
