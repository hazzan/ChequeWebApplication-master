using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChequeClient.Models
{
    public class MenuItems
    {
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}