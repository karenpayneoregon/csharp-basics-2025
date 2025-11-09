using System.Text.Json;
using AspCoreHelperLibrary;
using FluentValidation;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using NorthWind2024LocalLibrary.Classes;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Validators;

using static AspCoreHelperLibrary.WindowHelper;

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

        builder.Services.Configure<JsonOptions>(options =>
        {
            options.SerializerOptions.WriteIndented = true;
        });



        builder.Services.AddValidatorsFromAssemblyContaining<ContactValidator>();
        

        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        var efFileLogger = new DbContextToFileLogger();

        builder.Services.AddDbContextPool<Context>(options =>
        {
            options.UseSqlServer(connectionString);
            options.LogTo(efFileLogger.Log);

            if (builder.Environment.IsDevelopment())
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }
        });
        
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

        //app.ShowConsoleWindow();
        //app.SetConsoleWindowTitleWindows11("Payne code sample");

        app.Run();
    }
}

