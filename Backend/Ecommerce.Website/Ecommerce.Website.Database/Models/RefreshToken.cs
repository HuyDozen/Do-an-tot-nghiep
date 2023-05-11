using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class RefreshToken : BaseEntity
    {
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed  { get; set; }
        public bool IsRevoked   { get; set; }

        public DateTime ExpiredAt { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }

    }
}
