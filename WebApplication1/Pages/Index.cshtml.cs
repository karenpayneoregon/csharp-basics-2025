using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthWind2024LocalLibrary.Classes;
using NorthWind2024LocalLibrary.Data;
using System.Diagnostics;
using Serilog;

namespace WebApplication1.Pages;
public class IndexModel(Context context, IWebHostEnvironment env) : PageModel
{

    public void OnGet()
    {
        //var (contacts, contactTypes, countries) = SelectOptions.GetDefaultSelections(context);
        //Debugger.Break();

        // You can access the injected environment here.
        if (env.IsDevelopment())
        {
            Log.Information("Development environment detected.");
        }
    }
}
