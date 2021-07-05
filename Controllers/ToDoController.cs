using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAppWebAPI.Models;
using System.Security.Claims;
using DemoAppWebAPI.Services.ToDoService;
using DemoAppWebAPI.Dto.ToDoDto;
using Microsoft.AspNetCore.Authorization;

namespace DemoAppWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        //[AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return Ok(await _toDoService.GetToDoItems());
        }

        [HttpGet]
        [Route("User")]
       // [AllowAnonymous]
        public async Task<IActionResult> GetbyUser()
        {
            int UserId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            return Ok(await _toDoService.GetToDoItemsByUser(UserId));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var value =  await _toDoService.GetToDoItemById(Id);

            if (value == null)
                return NotFound(Id);

            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> AddTodo(AddToDoDto item)
        {           
            return Ok(await _toDoService.AddToDoItem(item));
        }
    }
}
