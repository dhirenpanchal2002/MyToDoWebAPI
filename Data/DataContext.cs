using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DemoAppWebAPI.Models;

namespace DemoAppWebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
        }

        public DbSet<ToDoItem> tbl_ToDoItems { get; set; }

        public DbSet<User> tbl_Users { get; set; }
    }
}
