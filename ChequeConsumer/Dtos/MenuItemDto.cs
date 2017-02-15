using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ChequeConsumer.Dtos
{
    [DataContract]
    public class MenuItemDto
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string MENUNAME { get; set; }
        [DataMember]
        public string MENUDESCRIPTION { get; set; }
        [DataMember]
        public string MENUCATEGORY { get; set; }
        [DataMember]
        public decimal Price { get; set; }  
    }
}

