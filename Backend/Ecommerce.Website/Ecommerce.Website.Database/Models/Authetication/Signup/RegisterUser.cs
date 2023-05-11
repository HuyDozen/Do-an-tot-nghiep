using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.Authetication.Signup
{
    public class RegisterUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }

    }
}
