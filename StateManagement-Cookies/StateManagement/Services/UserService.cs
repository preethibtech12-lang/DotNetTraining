using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;

namespace StateManagement.Services;

public class UserService : IUserService
{
    public List<User> users;
    public UserService() { 
        users = new List<User>();
        users.Add(new User { Email = "preethi@nihilent.com", Password = "123" });
        users.Add(new User { Email = "preethi@gmail.com", Password = "123" });
    }  

    public User Validate(string email, string password)
    {
        return users.FirstOrDefault(user=>user.Email == email && user.Password == password);
    }

}
