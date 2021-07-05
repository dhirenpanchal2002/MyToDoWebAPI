using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAppWebAPI.Dto.ToDoDto;
using DemoAppWebAPI.Models;

namespace DemoAppWebAPI.Services.ToDoService
{
    public interface IToDoService
    {
        Task<ServiceResponse<List<GetToDoDto>>> GetToDoItems();

        Task<ServiceResponse<List<GetToDoDto>>> GetToDoItemsByUser(int UserId);

        Task<ServiceResponse<GetToDoDto>> GetToDoItemById(int Id);

        Task<ServiceResponse<List<GetToDoDto>>> AddToDoItem(AddToDoDto item);
    }
}
