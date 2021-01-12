using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoWebAPI.Models;

namespace MyToDoWebAPI.Services.ToDoService
{
    public interface IToDoService
    {
        Task<ServiceResponse<List<ToDoItem>>> GetToDoItems();

        Task<ServiceResponse<ToDoItem>> GetToDoItemById(int Id);

        Task<ServiceResponse<List<ToDoItem>>> AddToDoItem(ToDoItem item);
    }
}
