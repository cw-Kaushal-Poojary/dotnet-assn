using Dapper;
using Dotnet_Assessment.Models;

namespace Dotnet_Assessment.DAL
{
    public interface IStockRepository
    {
        public Task<IEnumerable<Stock>> GetAllStocks(Filter filter);
    }

    public class StockRepository : IStockRepository
    {
        private readonly DatabaseContext _databaseContext;

        public StockRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Create a method that returns all stocks from the database
        public async Task<IEnumerable<Stock>> GetAllStocks(Filter filter)
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
            if (filter.MinBudget.HasValue)
            {
                stockQuery += " AND price >= @MinBudget";
                parameters.Add("MinBudget", filter.MinBudget);
            }

            // Check if maxBudget is not null
            if (filter.MaxBudget.HasValue)
            {
                stockQuery += " AND price <= @MaxBudget";
                parameters.Add("MaxBudget", filter.MaxBudget);
            }

            // Check if fuelTypes is not null
            if (filter.FuelTypes != null && filter.FuelTypes.Count > 0)
            {
                stockQuery += " AND fuel_type IN @FuelTypes";
                parameters.Add("FuelTypes", filter.FuelTypes);
            }

            IEnumerable<Stock> stocks = await connection.QueryAsync<Stock>(stockQuery, parameters);

            return stocks;
        }
    }
}