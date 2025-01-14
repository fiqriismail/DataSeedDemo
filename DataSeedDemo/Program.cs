using Microsoft.EntityFrameworkCore;
using DataSeedDemo.Data;
using DataSeedDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<DataSeedDemoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
        .UseSeeding((dbContext, _) =>
        {
            if (!dbContext.Set<Employee>().Any())
            {
                dbContext.Set<Employee>().AddRange(
                    new Employee { Name = "John Doe", Department = "IT", Email = "johndoe@example.com", Salary = 50000},
                    new Employee { Name = "Jane Doe", Department = "HR", Email = "janedoe@example.com", Salary = 60000},
                    new Employee { Name = "Alice", Department = "IT", Email = "alice@example.com", Salary = 70000}
                );
                dbContext.SaveChanges();
            }
        }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();

