using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyToDoWebAPI.Dto.ToDoDto;
using MyToDoWebAPI.Models;

namespace MyToDoWebAPI.Services.ToDoService
{
    public interface IToDoService
    {
        Task<ServiceResponse<List<GetToDoDto>>> GetToDoItems();

        Task<ServiceResponse<GetToDoDto>> GetToDoItemById(int Id);

        Task<ServiceResponse<List<GetToDoDto>>> AddToDoItem(AddToDoDto item);
    }
}
