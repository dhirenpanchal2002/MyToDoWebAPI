using DemoAppWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAppWebAPI.Data;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace DemoAppWebAPI.Services.AuthRepository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;
        public AuthRepository(DataContext dataContext,IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }
        public async Task<bool> IsUserExist(string username)
        {
            if (await _dataContext.tbl_Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower()))
            { 
                return true;
            }
            return false;
        }
        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            if(!await IsUserExist(username))
            {
                response.IsSuccess = false;
                response.Message = "User not found";                
            }
            else
            {
                User user = await _dataContext.tbl_Users.FirstOrDefaultAsync(c => c.UserName.ToLower() == username.ToLower());

                if(!VerifyPasswordHash(password,user.PwdHash,user.PwdSalt))
                {
                    response.IsSuccess = false;
                    response.Message = "Wrong Password";
                }
                else
                {
                    response.IsSuccess = true;
                    response.data = CreateToekn(user);
                    response.Message = "Successfully logged in..";
                }
            }

            return response;
        }
        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            if(await IsUserExist(user.UserName))
            {
                return new ServiceResponse<int> { data = 0, IsSuccess = false, Message = "User already exists" };
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PwdHash = passwordHash;
            user.PwdSalt = passwordSalt;

            await _dataContext.tbl_Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();

            ServiceResponse<int> response = new ServiceResponse<int>();
            response.data = user.Id;
            return response;
        }

        public async Task<ServiceResponse<string>> ChangePassword(string username, string password, string newpassword)
        {
            ServiceResponse<string> response = new ServiceResponse<string>();
            if (!await IsUserExist(username))
            {
                response.IsSuccess = false;
                response.Message = "User not found";
            }
            else
            {
                User user = await _dataContext.tbl_Users.FirstOrDefaultAsync(c => c.UserName.ToLower() == username.ToLower());

                if (!VerifyPasswordHash(password, user.PwdHash, user.PwdSalt))
                {
                    response.IsSuccess = false;
                    response.Message = "Wrong Password, authentication failed.";
                }
                else
                {
                    CreatePasswordHash(newpassword, out byte[] passwordHash, out byte[] passwordSalt);
                    user.PwdHash = passwordHash;
                    user.PwdSalt = passwordSalt;

                    object p = _dataContext.tbl_Users.Update(user);
                    await _dataContext.SaveChangesAsync();

                    response.Message = "Successfully changed the new password.";
                }
            }

            return response;
        }

        //Private method to generate the random Salt and then generate the hash based on the salt.
        private void CreatePasswordHash(string password,out  byte[] pwdHash,out  byte[] pwdSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                pwdSalt = hmac.Key;
                pwdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //Private method to verify the user pssword using db stored Salt and db stored password hash.
        private bool VerifyPasswordHash(string password, byte[] pwdHash, byte[] pwdSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512(pwdSalt))
            {
                byte[] UserpwdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                if (UserpwdHash.Length != pwdHash.Length)
                    return false;

                for (int i = 0; i < UserpwdHash.Length; i++)
                    if (UserpwdHash[i] != pwdHash[i])
                        return false;

                return true;
            }
        }

        private string CreateToekn(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.UserName)
            };

            SymmetricSecurityKey key1 = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            SigningCredentials cred = new SigningCredentials(key1, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor desc = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = cred
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(desc);

            return tokenHandler.WriteToken(token);
        }

        //private bool UpdateNewPassword(User user, string password)
        //{

        //}
    }
}
