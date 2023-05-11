using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string? Role { get; set;}
        public string? PhoneNumber { get; set; }
        public int Gender { get; set; }
        public virtual ICollection<Address>? Address { get; set; } 
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
        public virtual ICollection<Rating>? Ratings { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        //public virtual ICollection<New> News { get; set; }


    }
}
