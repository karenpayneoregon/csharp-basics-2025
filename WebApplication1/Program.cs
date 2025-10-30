using FluentValidation;
using Microsoft.EntityFrameworkCore;
using NorthWind2024LocalLibrary.Classes;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Validators;
using WebApplication1.Classes;

namespace WebApplication1;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorPages();

        builder.Services
            .AddRazorPages()
            .AddMvcOptions(options =>
            {
                // Add provider alongside the defaults
                options.ModelMetadataDetailsProviders.Add(new PascalCaseDisplayMetadataProvider());
            });

        builder.Services.AddValidatorsFromAssemblyContaining<ContactValidator>();
        

        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .EnableSensitiveDataLogging()
                    .LogTo(new DbContextToFileLogger().Log));
        }
        else
        {
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .LogTo(new DbContextToFileLogger().Log));
        }
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapRazorPages()
           .WithStaticAssets();

        app.Run();
    }
}

