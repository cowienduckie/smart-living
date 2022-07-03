using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SmartLiving.Api.Configurations;
using SmartLiving.Domain.Entities;
using SmartLiving.Domain.Models;

namespace SmartLiving.Api.Middleware
{
    public interface IUserService
    {
        Task<LoginResponseModel> Authenticate(LoginRequestModel model);
        IEnumerable<User> GetAllUsers();
        Task<User> GetUserByIdAsync(string id);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(
            IOptions<AppSettings> appSettings, 
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<LoginResponseModel> Authenticate(LoginRequestModel model)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false).ConfigureAwait(false);
            
            if (!loginResult.Succeeded) return null;

            var user = await _userManager.FindByNameAsync(model.UserName);

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new LoginResponseModel(user, token);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        // helper methods

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}