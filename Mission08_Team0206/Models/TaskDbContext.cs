using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0206.Models
{


    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options): base(options)
        {
        }
    
        public DbSet<TaskModel> Tasks { get; set; } // Accesses the Tasks table records and defines them in our program

        public DbSet<Category> Categories { get; set; } // Does the same for the Categories table
    }

}
