using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChequeClient.Models
{
    public class BillingDetails
    {
        public long Id { get; set; }
        public long MenuID { get; set; }
        public string MenuName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}