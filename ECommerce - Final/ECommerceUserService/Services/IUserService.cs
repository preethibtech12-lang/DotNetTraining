using System.Collections.Generic;
using ECommerceUserService.Models;

namespace ECommerceUserService.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
    }
}