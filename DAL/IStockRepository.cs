using Dotnet_Assessment.Models;

namespace Dotnet_Assessment.DAL
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllStocks(Filter filter);
    }
}