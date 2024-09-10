using System.Data;
using MySql.Data.MySqlClient;

public class DatabaseContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DatabaseContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
    }

    public IDbConnection CreateConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}