# About

Provides a peek at the basics of an ASP.NET Core application using Entity Framework Core.



## Topics

- Basic page view with hooks for CRUD operations
- Configured for [EF Code](https://learn.microsoft.com/en-us/ef/core/) page creation
- Configured for logging use [Serilog](https://www.nuget.org/packages/Serilog.AspNetCore/9.0.0?_src=template).
- Ready for working with [FluentValidation](https://github.com/FluentValidation/FluentValidation)
- Has custom JavaScript and CSS in `site.css` and `site.js`
- Uses [Areas](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/areas?view=aspnetcore-9.0) for better organization

### Partial Views

A [partial view](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/partial?view=aspnetcore-9.0) is a Razor markup file (.cshtml) without a @page directive that renders HTML output within another markup file's rendered output.



The following is resuable under `Areas`

```html
<partial name="~/Areas/Views/Shared/_AlertModal.cshtml" model="Model.Alert" />
```
`_AlertModal.cshtml` contains a Bootstrap modal dialog for displaying alerts.

See also [ASP.NET Core modals](https://dev.to/karenpayneoregon/asp-net-core-modals-3dlj) for more information and examples for Bootstrap 5.3.3 modals.

## Next Steps

- Using controllers and views
  - [Razor Pages with EF Core](https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/intro?view=aspnetcore-9.0)
  - [MVC with EF Core](https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-9.0)
- [Add sorting, filtering, and paging](https://learn.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-9.0)