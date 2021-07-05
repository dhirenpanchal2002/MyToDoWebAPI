using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAppWebAPI.Models;

namespace DemoAppWebAPI.Services.AuthRepository
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user,string password);

        Task<ServiceResponse<string>> Login(string username, string password);

        Task<bool> IsUserExist(string username);
                
        Task<ServiceResponse<string>> ChangePassword(string username, string password,string newpassword);

    }
}
