using AutoMapper;
using Dotnet_Assessment.DAL;
using Dotnet_Assessment.DTO;
using Dotnet_Assessment.Models;
using Dotnet_Assessment.Utils;

namespace Dotnet_Assessment.BAL
{
    public interface IStockService
    {
        public Task<IEnumerable<StockDto>> GetStocks(int? minBudget, int? maxBudget, string? fuelTypes);
    }

    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockService(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StockDto>> GetStocks(int? minBudget, int? maxBudget, string? fuelTypes)
        {
            // Format the fuel types
            int[] fuelIdsArray = FuelIdUtils.GetUniqueFuelIds(fuelTypes);

            // Call the repository to get the stocks
            IEnumerable<Stock> allStocksResponse = await _stockRepository.GetAllStocks(minBudget, maxBudget, fuelIdsArray);

            // Map the response to StockDto
            IEnumerable<StockDto> allStocks = _mapper.Map<IEnumerable<Stock>, IEnumerable<StockDto>>(allStocksResponse);

            return allStocks;
        }
    }
}