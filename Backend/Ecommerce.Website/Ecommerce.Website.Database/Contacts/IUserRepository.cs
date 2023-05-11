using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.Authetication;
using Ecommerce.Website.Database.Models.Authetication.Login;
using Ecommerce.Website.Database.Models.ResponseModels;

namespace Ecommerce.Website.Database.Contacts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        InforLogin Validate(Login model);
        TokenModel RenewToken(TokenModel model);
        UserRegister SignUpUser(User user);


    }
}
