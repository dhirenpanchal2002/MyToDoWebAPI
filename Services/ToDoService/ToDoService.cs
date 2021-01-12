using MyToDoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI.Services.ToDoService
{
    public class ToDoService : IToDoService
    {
        private static List<ToDoItem> items = new List<ToDoItem> {
            new ToDoItem{Id=1,Name="Book GP Appointment",Description="",Priority=ToDoItemPriority.High,IsActive=true},
            new ToDoItem{Id=2,Name="Buy Gift",Description="Description for id 2",Priority=ToDoItemPriority.Low,IsActive=true},
            new ToDoItem{Id=3,Name="Book Visa Appointment",Description="book visa appointment",Priority=ToDoItemPriority.Medium,IsActive=false}
        };
        public List<ToDoItem> AddToDoItem(ToDoItem item)
        {
            items.Add(item); 
            return items;
        }

        public ToDoItem GetToDoItemById(int Id)
        {
            return items.FirstOrDefault(X => X.Id == Id); 
        }

        public List<ToDoItem> GetToDoItems()
        {
            return items;
        }
    }
}
