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
        public async Task<ServiceResponse<List<ToDoItem>>> AddToDoItem(ToDoItem item)
        {
            items.Add(item);

            ServiceResponse<List<ToDoItem>> response = new ServiceResponse<List<ToDoItem>>();
            response.data = items;
            return response;
        }

        public async Task<ServiceResponse<ToDoItem>> GetToDoItemById(int Id)
        {            
            ServiceResponse<ToDoItem> response = new ServiceResponse<ToDoItem>();
            response.data = items.FirstOrDefault(X => X.Id == Id);
            return response;
        }

        public async Task<ServiceResponse<List<ToDoItem>>> GetToDoItems()
        {
            ServiceResponse<List<ToDoItem>> response = new ServiceResponse<List<ToDoItem>>();
            response.data = items;
            return response;
        }
    }
}
