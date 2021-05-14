using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoWebAPI.Services.AuthRepository;
using MyToDoWebAPI.Dto.User;
using Microsoft.EntityFrameworkCore;
using MyToDoWebAPI.Models;

namespace MyToDoWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserDto registerUserDto)
        {
           ServiceResponse<int> response = await _authRepo.Register(
               new Models.User { UserName = registerUserDto.UserName }, registerUserDto.Password);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto loginUserDto)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                loginUserDto.UserName, loginUserDto.Password);

            if (response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
