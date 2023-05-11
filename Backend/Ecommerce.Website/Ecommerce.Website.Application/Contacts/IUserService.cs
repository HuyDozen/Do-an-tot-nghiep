using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.Authetication;
using Ecommerce.Website.Database.Models.Authetication.Login;
using Ecommerce.Website.Database.Models.Authetication.Signup;
using Ecommerce.Website.Database.Models.ResponseModels;

 

namespace Ecommerce.Website.Application.Contacts
{
    public interface IUserService : IBaseService<User>
    {
        InforLogin Validate(Login model);
        TokenModel RenewToken(TokenModel model);
        public UserRegister SignUpUser(User user);



    }
}
