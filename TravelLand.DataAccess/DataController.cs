using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace TravelLand.DataAccess;

public abstract class DataController
{
    private readonly IConfiguration _configuration;

    private readonly string _tableName;

    protected DataController(IConfiguration configuration, string tableName)
    {
        _configuration = configuration;
        _tableName = tableName;
    }

    protected string ConnectionString => _configuration.GetConnectionString("DefaultConnection");

    protected SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }

    protected string PrepareStoredProcedureName(string storedProcedureEnding, bool buildName)
    {
        return buildName ? storedProcedureEnding : $"sp_{_tableName}_{storedProcedureEnding}";
    }

    protected string PrepareStoredProcedureName(string storedProcedureEnding)
    {
        return $"sp_{_tableName}_{storedProcedureEnding}";
    }

    protected Task<bool> InsertAsync(object parameters)
    {
        return PerformNonQuery("Insert", parameters);
    }

    protected Task<bool> UpdateAsync(object parameters)
    {
        return PerformNonQuery("Update", parameters);
    }

    protected async Task<bool> PerformNonQuery(string storedProcedureName, object parameters, bool customName = false)
    {
        var storedProcedure = PrepareStoredProcedureName(storedProcedureName, customName);

        using (var connection = GetConnection())
        {
            await connection.OpenAsync();
            var rows = await connection.ExecuteAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
            return rows > 0;
        }
    }

    protected async Task<IEnumerable<TModel>> GetManyAsync<TModel>(string storedProcedureName, object parameters = null,
        bool customName = false)
        where TModel : class
    {
        var storedProcedure = PrepareStoredProcedureName(storedProcedureName, customName);
        using (var connection = GetConnection())
        {
            await connection.OpenAsync();

            var rows = await connection.QueryAsync<TModel>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
            return rows;
        }
    }

    protected async Task<TModel> GetOneAsync<TModel>(string storedProcedureName, object parameters = null,
        bool customName = false)
    {
        var storedProcedure = PrepareStoredProcedureName(storedProcedureName, customName);

        using (var connection = GetConnection())
        {
            await connection.OpenAsync();
            var row = await connection.QueryFirstOrDefaultAsync<TModel>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
            return row;
        }
    }

    protected async Task<TModel> GetCountAsync<TModel>(string storedProcedureName, object parameters = null,
        bool customName = false)
    {
        var storedProcedure = PrepareStoredProcedureName(storedProcedureName, customName);
        using (var connection = GetConnection())
        {
            await connection.OpenAsync();
            var row = await connection.ExecuteScalarAsync<TModel>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);
            return row;
        }
    }
}