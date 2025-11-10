using AspCoreHelperLibrary;
using FluentValidation;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using NorthWind2024LocalLibrary.Classes;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Validators;
using System.Text.Json;
using System.Text.Json.Serialization;
using static AspCoreHelperLibrary.WindowHelper;
// ReSharper disable InvertIf

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
                // split PascalCase property names into separate words for display
                options.ModelMetadataDetailsProviders.Add(new PascalCaseDisplayMetadataProvider());
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

        builder.Services.AddHostedService<EfCoreWarmupService>();

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

