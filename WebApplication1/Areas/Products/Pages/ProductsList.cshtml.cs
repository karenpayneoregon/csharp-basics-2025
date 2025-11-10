using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Models;

namespace WebApplication1.Areas.Products.Pages;

/// <summary>
/// Represents the model for the Products List page in the Products area of the application.
/// </summary>
/// <remarks>
/// This class is responsible for retrieving and managing the list of products to be displayed
/// on the Products List page. It utilizes the provided <see cref="Context"/> to query the database
/// and includes related entities such as <see cref="Category"/> and <see cref="Supplier"/>.
/// </remarks>
public class ProductsListModel(Context context) : PageModel
{
    public IList<Product> Product { get;set; } = null!;

    public async Task OnGetAsync()
    {
        Product = await context.Products
            .AsNoTracking()
            .Include(p => p.Category)
            .Include(p => p.Supplier).ToListAsync();
    }
}