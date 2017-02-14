using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChequeConsumer.Interface;
using ChequeConsumer;

namespace ChequeClient.Controllers
{
    public class ChequeBaseController : Controller
    {
        /// <summary>
        /// MenuItem Consumer instance.
        /// </summary>
        private IMenuItemConsumer menuItemConsumer;

        /// <summary>
        /// MenuItem Consumer instance.
        /// </summary>
        private ISOAPServiceMenuItemConsumer saopServiceMenuItemConsumer;  
        
        /// <summary>
        /// Get the MenuItemConsumer.
        /// </summary>
        public IMenuItemConsumer MenuItemConsumer  
        {
            get { return menuItemConsumer ?? (menuItemConsumer = new MenuItemConsumer()); }
            set { menuItemConsumer = value; }
        }

        /// <summary>
        /// Get the MenuItemConsumer.
        /// </summary>
        public ISOAPServiceMenuItemConsumer SaopServiceMenuItemConsumer 
        {
            get { return saopServiceMenuItemConsumer ?? (saopServiceMenuItemConsumer = new SOAPServiceMenuItemConsumer()); }
            set { saopServiceMenuItemConsumer = value; }
        }

    }
}
