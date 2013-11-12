using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fitlife.WebUI.Models
{
    public class HomeViewModel
    {
        public ContactUs ContactUsMail { get; set; }
    }

    public class ContactUs
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}