using BLL.Abstraction;
using BLL.Models;
using Common.Helpers;
using DAL.Abstraction;
using Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserBusiness : BaseBusiness<User>
    {
        private readonly AppSettings _appSettings;

        public UserBusiness(IRepository<User> _repository, IOptions<AppSettings> appSettings) : base(_repository)
        {
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await this.Get("Username", model.Username, "Password", model.Password).ConfigureAwait(false);
            if (user == null || user.Count == 0) return null;
            // authentication successful so generate jwt token
            var token = generateJwtToken(user[0]);
            return new AuthenticateResponse(user[0], token);
        }

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.ID.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}