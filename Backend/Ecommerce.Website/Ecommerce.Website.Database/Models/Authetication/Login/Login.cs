

using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Website.Database.Models.Authetication.Login
{
    public class Login
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
