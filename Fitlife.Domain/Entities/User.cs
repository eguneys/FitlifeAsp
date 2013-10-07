using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitlife.Domain.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }
    }
}
