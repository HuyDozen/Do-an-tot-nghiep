using Ecommerce.Website.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Presentation.Dtos
{
    public  class UserDto 
    {
        public string Username 
        {
            get;set;
           
        }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Address>? Address { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

    }
}
