using System.Collections.Generic;
using LamViecVoiData.Models;
using Microsoft.EntityFrameworkCore;

namespace LamViecVoiData.Data
{
    public class AppDbContext : DbContext
    {
        
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Employee> Employees { get; set; }
        
    }
}
