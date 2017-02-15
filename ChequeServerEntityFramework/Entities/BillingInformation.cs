using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChequeServerEntityFramework.Entities
{
    public class BillingInformation
    {
        public BillingInformation()
        {
            this.MenuItems = new HashSet<MenuItem>();
        }

        public string ChequeNo { get; set; }
        public DateTime ChequeDate { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
