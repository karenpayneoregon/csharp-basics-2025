using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NorthWind2024LocalLibrary.Data;
using NorthWind2024LocalLibrary.Models;

namespace WebApplication1.Areas.Products.Pages
{
    public class ProductsListModel(Context context) : PageModel
    {
        public IList<Product> Product { get;set; } = null!;

        public async Task OnGetAsync()
        {
            Product = await context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();
        }
    }
}
