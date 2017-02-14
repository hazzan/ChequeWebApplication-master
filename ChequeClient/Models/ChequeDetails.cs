using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChequeConsumer.Dtos;

namespace ChequeClient.Models
{
    public class ChequeDetails
    {
        public IList<MenuItemDto> ListOfMenu { get; set; }
        public List<MenuItemDto> SelectedMenuItem { get; set; } 
        //public string LeftselectedItem { get; set; }
        //public string RightselectedItem { get; set; }
        public string Invoicenumber { get; set; }
        public string InvoiceDate { get; set; }
        public string Status { get; set; }
        public string RestOrSaop { get; set; } 
    }
}