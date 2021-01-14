using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MyToDoWebAPI.Dto.ToDoDto;
using MyToDoWebAPI.Models;

namespace MyToDoWebAPI
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ToDoItem, GetToDoDto>();
            CreateMap<AddToDoDto, ToDoItem>();
        }
    }
}
