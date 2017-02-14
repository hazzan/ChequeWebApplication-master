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
        public string MenuName { get; set; }
        [DataMember]
        public string MenuDescription { get; set; }
        [DataMember]
        public string Category { get; set; }
        [DataMember]
        public decimal Price { get; set; }  
    }
}

