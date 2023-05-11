using Ecommerce.Website.Database.Contacts;
using Ecommerce.Website.Database.Data;
using Ecommerce.Website.Database.Models;
using Ecommerce.Website.Database.Models.Authetication;
using Ecommerce.Website.Database.Models.Authetication.Login;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;
using Ecommerce.Website.Database.Models.ResponseModels;
using Ecommerce.Website.Database.Models.Authetication.Signup;

namespace Ecommerce.Website.Database.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly EcommerceContext _context;
        private readonly AppSettings _appSetting;


        public UserRepository(EcommerceContext context, IOptionsMonitor<AppSettings> optionsMonitor) : base(context)
        {
            _context = context;
            //Tu dong map
            _appSetting = optionsMonitor.CurrentValue; // Lấy đúng giá trị
        }

        public InforLogin Validate(Login model)
        { 
            var user = _context.Users.SingleOrDefault(p => p.Username == model.UserName
                && model.Password == p.Password);
            if (user == null)
            {
                return null;
            }
            else
            {
                var reponse = new InforLogin()
                {
                    UserId = user.Id,
                    Email = user.Email,
                    FullName = user.FullName,
                    Age = user.Age,
                    Auth = true,
                    UserName = model.UserName,
                    tokenModel = GenerationToken(user),
                    Role = user.Role

                };

                return reponse;
            }
            
            
        }

        /// <summary>
        /// Hàm dùng riêng cho lớp
        /// Config mã token
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Chuỗi ký tự mã </returns>
        private TokenModel GenerationToken(User user)
        {
            var JwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                // Quyền sở hữu
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserName", user.Username),
                    new Claim("Id", user.Id.ToString()),

                    //Roles

                }),

                // Time hết hạn là bao nhiều
                Expires = DateTime.UtcNow.AddMinutes(60),

                // Ký tá
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (secretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var token = JwtTokenHandler.CreateToken(tokenDescription);

            // Trả về một chuỗi
            var accessToken = JwtTokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            //Luu vao database
            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                JwtId = token.Id,
                Token = refreshToken,
                IsUsed = false,
                IsRevoked = false,
                //CreatedDate = DateTime.UtcNow,
                ExpiredAt = DateTime.UtcNow.AddHours(1) //test
            };

            _context.Add(refreshTokenEntity);
            _context.SaveChanges();
            return new TokenModel
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private string GenerateRefreshToken()
        {
            var random = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(random);
                return Convert.ToBase64String(random);
            }
        }

        public TokenModel RenewToken(TokenModel model)
        {
            var JwtTokenHandler = new JwtSecurityTokenHandler();
            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSetting.SecretKey);
            var tokenValidatedParam = new TokenValidationParameters
            {
                // Tự cấp token
                ValidateIssuer = false, //Tự cấp, nếu cấp phải chỉ dịch vụ mih chọn
                ValidateAudience = false,

                // Ký vào token
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes), // Sử dụng thuật toán đối xứng

                ClockSkew = TimeSpan.Zero,

                ValidateLifetime = false //Chan ko cho kt token con han
            };

            // check 1: AccessToken co dug dinh dang
            var tokenInVerification = JwtTokenHandler.ValidateToken(model.AccessToken, tokenValidatedParam,
                out var validatedToken);

            // check 2: Kiem tra alg
            if (validatedToken is JwtSecurityToken jwtSecurityToken)
            {
                var result = jwtSecurityToken.Header.Alg.Equals
                    (SecurityAlgorithms.HmacSha512, StringComparison.InvariantCultureIgnoreCase);
                if (!result)
                {
                    throw new InvalidOperationException();
                    //Invalid Token
                }
            }
            //check 3: check accessToken expire
            var utcExperienceDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x =>
            x.Type == JwtRegisteredClaimNames.Exp).Value);

            var expireDate = ConvertUnixTimeToDateTime(utcExperienceDate);
            if (expireDate > DateTime.UtcNow)
            {
                throw new InvalidOperationException();
                //AccessToken chua dc expired
            }

            //check 4: check refresh Token exist in db
            var storedToken = _context.RefreshTokens.FirstOrDefault(x => x.Token == model.RefreshToken);
            if (storedToken == null)
            {
                throw new InvalidOperationException();
                //RefreshToken ko ton tai
            }
            //check 5: check refreshToken is used/revoked?
            if (storedToken.IsUsed)
            {
                throw new InvalidOperationException();
                //RefreshToken dang dc su dung
            }
            if (storedToken.IsRevoked)
            {
                throw new InvalidOperationException();
                //RefreshToken dang dc revoked
            }

            //check 6: accessToken id == JwtId in RefreshToken
            var jti = tokenInVerification.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti).Value;
            if (storedToken.JwtId != jti)
            {
                throw new InvalidOperationException();
                //Token ko match
            }

            //check 7: Update token is used
            storedToken.IsRevoked = true;
            storedToken.IsUsed = true;

            _context.Update(storedToken);
            _context.SaveChanges();

            //Create new token

            var user = _context.Users.SingleOrDefault(nd => nd.Id == storedToken.UserId);
            var token = GenerationToken(user);

            throw new InvalidOperationException();//true, renew token access
        }


        public UserRegister SignUpUser(User user)
        {
            if (_context.Users.Where(u => u.Email == user.Email).FirstOrDefault() != null)
            {
                return null;
            }
            else
            {
               
                user.CreatedDate = DateTime.Now;
                user.ModifiedDate = DateTime.Now;
                user.IsDeleted = false;
                user.Role = "user";
                user.CreatedBy = user.Email;
                user.ModifiedBy = user.Email;
                var result = new UserRegister()
                {
                    FullName = user.FullName,
                    Age = user.Age,
                    Password = user.Password,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Username = user.Username,
                    Role = "user",
                    IsDeleted = false,
                    ModifiedDate = DateTime.Now,
                    CreatedDate = DateTime.Now,
                    Gender = user.Gender,
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                if (result != null)
                {
                    
                    return result;
                }
                else
                {
                    return null;
                }


                
            }
            
        }

        private DateTime ConvertUnixTimeToDateTime(long utcExperienceDate)
        {
            var dateTimeInterval = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeInterval.AddSeconds(utcExperienceDate).ToUniversalTime();

            return dateTimeInterval;
        }
    }
}
