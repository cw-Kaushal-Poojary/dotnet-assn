using Dapper;
using Dotnet_Assessment.Models;

namespace Dotnet_Assessment.DAL
{
    public interface IStockRepository
    {
        public Task<IEnumerable<Stock>> GetAllStocks(int? minBudget, int? maxBudget, int[] fuelTypes);
    }

    public class StockRepository : IStockRepository
    {
        private readonly DatabaseContext _databaseContext;

        public StockRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Create a method that returns all stocks from the database
        public async Task<IEnumerable<Stock>> GetAllStocks(int? minBudget, int? maxBudget, int[] fuelTypes)
        {
            using var connection = _databaseContext.CreateConnection();

            string stockQuery = @"
                SELECT 
                    id AS Id, 
                    make_year AS MakeYear, 
                    make_name AS MakeName, 
                    model_name AS ModelName, 
                    price AS Price, 
                    km AS Km, 
                    fuel_type AS FuelType, 
                    image AS Image, 
                    city AS City 
                FROM stocks 
                WHERE 1=1";

            // Create a dynamic parameters object
            var parameters = new DynamicParameters();

            // Check if minBudget is not null
            if (minBudget.HasValue)
            {
                stockQuery += " AND price >= @MinBudget";
                parameters.Add("MinBudget", minBudget);
            }

            // Check if maxBudget is not null
            if (maxBudget.HasValue)
            {
                stockQuery += " AND price <= @MaxBudget";
                parameters.Add("MaxBudget", maxBudget);
            }

            // Check if fuelTypes is not null
            if (fuelTypes != null && fuelTypes.Length > 0)
            {
                stockQuery += " AND fuel_type IN @FuelTypes";
                parameters.Add("FuelTypes", fuelTypes);
            }

            IEnumerable<Stock> stocks = await connection.QueryAsync<Stock>(stockQuery, parameters);

            return stocks;
        }
    }
}