using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NorthWind2024LocalLibrary.Classes;
using NorthWind2024LocalLibrary.Data;
using System.Diagnostics;

namespace WebApplication1.Pages;
public class IndexModel(Context context) : PageModel
{

    public void OnGet()
    {
        //var (contacts, contactTypes, countries) = SelectOptions.GetDefaultSelections(context);
        //Debugger.Break();
    }
}
