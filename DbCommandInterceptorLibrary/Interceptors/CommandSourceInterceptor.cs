using DbPeekQueryLibrary.LanguageExtensions;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace DbCommandInterceptorLibrary.Interceptors;

/// <summary>
/// Represents an interceptor for database commands that provides additional functionality 
/// when executing commands in Entity Framework Core.
/// </summary>
/// <remarks>
/// This class extends <see cref="DbCommandInterceptor"/> 
/// to inspect and log database commands, particularly during save operations. It allows for 
/// custom handling of command execution, such as logging command text and providing insights 
/// into the command source.
/// </remarks>
public class CommandSourceInterceptor : DbCommandInterceptor
{
    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command, 
        CommandEventData eventData, 
        InterceptionResult<DbDataReader> result)
    {
        
        if (eventData.CommandSource != CommandSource.SaveChanges) return result;

        using StreamWriter writer = new("CommandSourceInterceptor.txt", append: true);
        writer.WriteLine($"Saving changes for {eventData.Context!.GetType().Name}");
        writer.WriteLine("Command text for EF Core Command object from Karen's package");
        writer.WriteLine(command.ActualCommandText());
        writer.WriteLine("Command text for EF Core Command object raw");
        writer.WriteLine(command.CommandText);
        
        return result;
        
    }
}