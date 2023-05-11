using Ecommerce.Website.Application.Contacts;
using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.Authetication;
using Ecommerce.Website.Database.Models.Authetication.Login;
using Ecommerce.Website.Database.Models.ResponseModels;
using Ecommerce.Website.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Website.Application.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public InforLogin Validate(Login model)
        {
           return _userRepository.Validate(model);
        }
        public TokenModel RenewToken(TokenModel model)
        {
           return  _userRepository.RenewToken(model);
        }

        public UserRegister SignUpUser(User user)
        {
            return _userRepository.SignUpUser(user);
        }
    }
}
