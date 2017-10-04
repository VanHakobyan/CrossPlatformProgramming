using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.Model
{
    public class First : DbContext
    {
        public First(DbContextOptions<First> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
