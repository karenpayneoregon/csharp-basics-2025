using ConsoleConfigurationLibrary.Classes;
using MenuSampleApp.Classes.Core;
using Microsoft.Data.SqlClient;
using Serilog;
using static MenuSampleApp.Classes.Core.SpectreConsoleHelpers;

namespace MenuSampleApp.Classes;
internal class Operations
{

    private static readonly string databaseName = DataOperations.InitialCatalogFromConnectionString(AppConnections.Instance.MainConnection);
    private static bool DatabaseExists()
    {
        return DataOperations.ExpressDatabaseExists(databaseName);
    }
    /// <summary>
    /// Displays the count of tables and their respective row counts in the NorthWind database.
    /// </summary>
    /// <remarks>
    /// This method retrieves the database name from the application's main connection string.
    /// It checks if the database exists and, if so, fetches and displays the table names along with their row counts.
    /// If the database does not exist, it logs an informational message and notifies the user.
    /// </remarks>
    /// <exception cref="SqlException">
    /// Thrown if there is an issue connecting to the database or executing the SQL commands.
    /// </exception>
    public static void NorthWindTableCount()
    {

        PrintCyan();


        if (DatabaseExists())
        {
            var tables = DataOperations.TablesCount(AppConnections.Instance.MainConnection);
            foreach (var table in tables)
            {
                Console.WriteLine($"{table.TableName,-25}{table.RowCount}");
            }
        }
        else
        {
            Console.WriteLine($"Database {databaseName} does not exist.");
            Log.Information("Database {databaseName} does not exist.", databaseName);
        }


        Continue();

    }
    /// <summary>
    /// Executes a predefined operation and provides feedback to the user.
    /// </summary>
    /// <remarks>
    /// This method serves as a placeholder for performing a specific operation. 
    /// It outputs a message indicating the operation is being performed and then 
    /// waits for user interaction to continue.
    /// </remarks>
    public static void PerformOperation()
    {
        // Placeholder for performing a specific operation
        Console.WriteLine($"Performing operation.");

        Continue();
    }

    /// <summary>
    /// Displays the list of categories from the database, including their IDs and names.
    /// </summary>
    /// <remarks>
    /// This method checks if the database exists before attempting to retrieve the categories.
    /// If the database exists, it fetches the list of categories and displays their IDs and names.
    /// If the database does not exist, it logs an informational message and notifies the user.
    /// </remarks>
    /// <exception cref="SqlException">
    /// Thrown if there is an issue connecting to the database or executing the SQL commands.
    /// </exception>
    public static void ViewCategories()
    {
        PrintCyan();

        if (DatabaseExists())
        {
            var categories = DataOperations.GetCategories();
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryId}: {category.CategoryName}");
            }

        }
        else
        {
            Console.WriteLine($"Database {databaseName} does not exist.");
            Log.Information("Database {databaseName} does not exist.", databaseName);
        }


        Continue();
    }

    /// <summary>
    /// Exits the application immediately by terminating the current process.
    /// </summary>
    /// <remarks>
    /// This method calls <see cref="Environment.Exit(int)"/> with an exit code of 0,
    /// which indicates a successful termination of the application.
    /// </remarks>
    public static void ExitApplication()
    {
        Environment.Exit(0);
    }
}
