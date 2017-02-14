using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ChequeConsumer.Dtos
{
    [DataContract]
    public class MenuItemResultDto
    {
        [DataMember(Name="MenuItemResult")]
        public List<MenuItemDto> MenuItemResult { get; set; }
    }
}
