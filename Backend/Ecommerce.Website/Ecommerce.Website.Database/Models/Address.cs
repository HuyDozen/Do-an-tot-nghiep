using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models
{
    public class Address : BaseEntity
    {
        public string LineFirst { get; set; }
        public string LineSecond { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; } 
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }

        #region Lk với bảng khoá ngoại 1 - n
        public int UserId { get; set; }
        public virtual User? User { get; set; } 
        #endregion
    }
}
