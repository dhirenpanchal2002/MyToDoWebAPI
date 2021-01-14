using MyToDoWebAPI.Dto.ToDoDto;
using MyToDoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyToDoWebAPI.Data;

namespace MyToDoWebAPI.Services.ToDoService
{
    public class ToDoService : IToDoService
    {
        //private static List<ToDoItem> items = new List<ToDoItem> {
        //    new ToDoItem{Id=1,Name="Book GP Appointment",Description="",Priority=ToDoItemPriority.High,IsActive=true},
        //    new ToDoItem{Id=2,Name="Buy Gift",Description="Description for id 2",Priority=ToDoItemPriority.Low,IsActive=true},
        //    new ToDoItem{Id=3,Name="Book Visa Appointment",Description="book visa appointment",Priority=ToDoItemPriority.Medium,IsActive=false}
        //};

        private readonly IMapper _todoMapper;
        private readonly DataContext _dbContext;

        public ToDoService(IMapper todoMapper,DataContext dbContext)
        {
            _todoMapper = todoMapper;
            _dbContext = dbContext;
        }
        public async Task<ServiceResponse<List<GetToDoDto>>> AddToDoItem(AddToDoDto item)
        {
            ToDoItem newItem = _todoMapper.Map<ToDoItem>(item);
            await _dbContext.tbl_ToDoItems.AddAsync(newItem);
            await _dbContext.SaveChangesAsync();

            List<ToDoItem> dbitems = await _dbContext.tbl_ToDoItems.ToListAsync();
            ServiceResponse <List<GetToDoDto>> response = new ServiceResponse<List<GetToDoDto>>();
            response.data = (dbitems.Select(C => _todoMapper.Map<GetToDoDto>(C))).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetToDoDto>> GetToDoItemById(int Id)
        {            
            ServiceResponse<GetToDoDto> response = new ServiceResponse<GetToDoDto>();
            ToDoItem dbitem = await _dbContext.tbl_ToDoItems.FirstOrDefaultAsync(X => X.Id == Id);
            response.data = _todoMapper.Map<GetToDoDto>(dbitem);
            return response;
        }

        public async Task<ServiceResponse<List<GetToDoDto>>> GetToDoItems()
        {
            ServiceResponse<List<GetToDoDto>> response = new ServiceResponse<List<GetToDoDto>>();
            List<ToDoItem> dbitems = await _dbContext.tbl_ToDoItems.ToListAsync();
            response.data = _todoMapper.Map<List<GetToDoDto>>(dbitems);
            //response.data = (items.Select(C => _todoMapper.Map<GetToDoDto>(C))).ToList();
            return response;
        }
    }
}
