using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using NorthWind2024LocalLibrary.Data;
using Microsoft.Extensions.Hosting;

namespace NorthWind2024LocalLibrary.Classes;

/// <summary>
/// Represents a hosted service designed to warm up Entity Framework Core by initializing the model
/// and executing a lightweight query. This ensures that query compilation and model initialization
/// are performed during application startup, improving runtime performance.
/// </summary>
public class EfCoreWarmupService(IServiceProvider serviceProvider) : IHostedService
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<Context>();
            _ = dbContext.Model;

            // Execute a simple, lightweight query to warm up query compilation
            await dbContext.Categories.Take(1).AnyAsync(cancellationToken); 
        }
        
        await Task.CompletedTask;
        
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}