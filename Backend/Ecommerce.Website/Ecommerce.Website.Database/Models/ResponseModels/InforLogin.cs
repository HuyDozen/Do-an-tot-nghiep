using Ecommerce.Website.Database.Models.Authetication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Database.Models.ResponseModels
{
    public class InforLogin
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public bool Auth { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public string Role { get; set; }
        public TokenModel tokenModel { get; set; } 
    }
}
