using DataSeedDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DataSeedDemo.Data;

public class DataSeedDemoDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    public DataSeedDemoDbContext(DbContextOptions<DataSeedDemoDbContext> options) : base(options)
    {
    }
    
}