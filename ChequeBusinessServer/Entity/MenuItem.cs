using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChequeBusinessData.Entity
{
    public class MenuItem
    {
        public long Id { get; set; }
        public string MenuName { get; set; }
        public string MenuDescription { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
    }
}
