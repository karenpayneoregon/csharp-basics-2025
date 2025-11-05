using System.Data;
using Dapper;
using EnumHasConversionDapper.Models;
using Microsoft.Data.SqlClient;
using StrEnum.Dapper;
using static ConfigurationLibrary.Classes.ConfigurationHelper;

namespace EnumHasConversionDapper.Classes;

/// <summary>
/// Provides operations for managing and retrieving wine data from the database.
/// </summary>
public class WineOperations
{

    private readonly IDbConnection _dbConnection = new SqlConnection(ConnectionString());
    
    /// <summary>
    /// Initializes a new instance of the <see cref="WineOperations"/> class.
    /// Configures the Dapper library to use string-based enumerations for database operations.
    /// </summary>
    public WineOperations()
    {
        StrEnumDapper.UseStringEnums();
    }

    /// <summary>
    /// Retrieves a list of all wines from the database, ordered by their name and type.
    /// </summary>
    /// <returns>A list of <see cref="Wine"/> objects representing all wines in the database.</returns>
    public List<Wine> AllWines()
    {
        const string statement =
            """
            SELECT WineId
                ,Name
                ,WineType
            FROM dbo.Wines
            ORDER BY Name, WineType
            """;

        return _dbConnection.Query<Wine>(statement).AsList();
    }
}
