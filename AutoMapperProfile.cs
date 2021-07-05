using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoAppWebAPI.Dto.ToDoDto;
using DemoAppWebAPI.Models;

namespace DemoAppWebAPI
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
