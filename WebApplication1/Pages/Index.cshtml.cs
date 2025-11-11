using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthWind2024LocalLibrary.Classes;
using NorthWind2024LocalLibrary.Data;
using System.Diagnostics;
using Serilog;

namespace WebApplication1.Pages;

/// <summary>
/// Represents the model for the Index page in the application.
/// </summary>
/// <remarks>
/// This class is responsible for handling the logic and data for the Index page.
/// It inherits from <see cref="PageModel"/> and utilizes dependency injection
/// to access the <see cref="Context"/> for database operations and the <see cref="IWebHostEnvironment"/>
/// for environment-specific configurations.
/// </remarks>
public class IndexModel(Context context, IWebHostEnvironment env) : PageModel
{

    public void OnGet()
    {
        //var (contacts, contactTypes, countries) = SelectOptions.GetDefaultSelections(context);
        //Debugger.Break();

        var cats = context.Categories.ToList();
        // You can access the injected environment here.
        if (env.IsDevelopment())
        {
            Log.Information("Development environment detected.");
        }
    }
}
