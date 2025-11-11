using System.Diagnostics;
using DbCommandInterceptorLibrary.Classes.Configuration;
using DbCommandInterceptorLibrary.Interceptors;
using DbCommandInterceptorLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace DbCommandInterceptorLibrary.Data;

public class CustomersContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (Debugger.IsAttached)
        {
            optionsBuilder
                .EnableSensitiveDataLogging()
                .AddInterceptors(new AuditInterceptor())
                .AddInterceptors(new CommandSourceInterceptor())
                .UseSqlServer(ConnectionReader.GetMainConnectionString());
        }
        else
        {
            optionsBuilder
                .AddInterceptors(new AuditInterceptor())
                .AddInterceptors(new CommandSourceInterceptor())
                .UseSqlServer(ConnectionReader.GetMainConnectionString());

        }
    }
}