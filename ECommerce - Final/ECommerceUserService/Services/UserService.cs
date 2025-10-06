
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using ECommerceUserService.Repository;
using ECommerceUserService.Helpers;
using ECommerceUserService.Models;
using System.Text.Json;

namespace ECommerceUserService.Services
{ 
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var users = await _userRepository.GetAll();
            var user = users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
            if (user == null) return null;
            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> user = await _userRepository.GetAll();
            return user;
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        private string generateJwtToken(User user)
        {
            
            Console.WriteLine( "user: "+ JsonSerializer.Serialize(user));
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserId", user.UserId.ToString()),
                                                     new Claim("role",user.Role)}),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), 
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
