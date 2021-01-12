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
        public IActionResult Get()
        {
            return Ok(_toDoService.GetToDoItems());
        }
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var value = _toDoService.GetToDoItemById(Id);

            if (value == null)
                return NotFound(Id);

            return Ok(value);
        }
        [HttpPost]
        public IActionResult AddTodo(ToDoItem item)
        {           
            return Ok(_toDoService.AddToDoItem(item));
        }
    }
}
