using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitlife.WebUI.Models
{
    public class NavViewModel
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }

        public bool AllowAnonymous { get; set; }
        
    }
}