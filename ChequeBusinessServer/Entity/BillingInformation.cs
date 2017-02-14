using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChequeBusinessData.Entity
{
    public class BillingInformation
    {

        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
