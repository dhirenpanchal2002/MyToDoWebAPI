using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoWebAPI.Models;

namespace MyToDoWebAPI.Services.ToDoService
{
    public interface IToDoService
    {
        List<ToDoItem> GetToDoItems();

        ToDoItem GetToDoItemById(int Id);

        List<ToDoItem> AddToDoItem(ToDoItem item);
    }
}
