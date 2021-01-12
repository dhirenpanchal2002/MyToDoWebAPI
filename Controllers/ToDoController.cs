using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoWebAPI.Models;
using MyToDoWebAPI.Services.ToDoService;

namespace MyToDoWebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _toDoService.GetToDoItems());
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
        public async Task<IActionResult> AddTodo(ToDoItem item)
        {           
            return Ok(await _toDoService.AddToDoItem(item));
        }
    }
}
