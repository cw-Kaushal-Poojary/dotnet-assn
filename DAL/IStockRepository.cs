using Dotnet_Assessment.Models;

namespace Dotnet_Assessment.DAL
{
    public interface IStockRepository
    {
        public Task<IEnumerable<Stock>> GetAllStocks(Filter filter);
    }
}