using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChequeConsumer.Dtos;

namespace ChequeConsumer.Interface
{
    public interface IMenuItemConsumer 
    {
        List<MenuItemDto> LoadMenuItem();
        string InsertChequeInfoByRest(List<BillingInformationDto> listBillingDto, DateTime chequeDate, string chequeNo);
    }
}
