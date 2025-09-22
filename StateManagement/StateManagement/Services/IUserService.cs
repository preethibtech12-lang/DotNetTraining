using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using StateManagement.Models;

namespace StateManagement.Services;

public interface IUserService 
{
   User Validate(string email, string password);    
}
