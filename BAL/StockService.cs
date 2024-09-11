using AutoMapper;
using Dotnet_Assessment.DAL;
using Dotnet_Assessment.DTO;
using Dotnet_Assessment.Enums;
using Dotnet_Assessment.Models;
using Dotnet_Assessment.Utils;

namespace Dotnet_Assessment.BAL
{
    public interface IStockService
    {
        public Task<StockResultDTO> GetStocks(RequestDto requestDto);
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

        public async Task<StockResultDTO> GetStocks(RequestDto requestDto)
        {
            // Check if the minBudget is greater than the maxBudget
            if (requestDto.MinBudget.HasValue &&
                requestDto.MaxBudget.HasValue &&
                requestDto.MinBudget > requestDto.MaxBudget
            )
            {
                return new StockResultDTO
                {
                    Status = false,
                    StatusCode = 400,
                    Message = "Min budget cannot be greater than max budget",
                    Stocks = null
                };
            }

            // Map the request to Filter
            Filter filter = _mapper.Map<RequestDto, Filter>(requestDto);

            // Format the fuel types
            List<FuelType> fuelIdsArray = FuelIdUtils.GetUniqueFuelIds(requestDto.FuelIds);

            // Check if the fuelIdsArray has any values less than 1 or greater than 6
            if (fuelIdsArray.Any(fuelId => fuelId < FuelType.Petrol || fuelId > FuelType.Hybrid))
            {
                return new StockResultDTO
                {
                    Status = false,
                    StatusCode = 400,
                    Message = "Invalid fuel type",
                    Stocks = null
                };
            }

            // Add the fuel types to the filter
            filter.FuelTypes = fuelIdsArray;

            // Call the repository to get the stocks
            IEnumerable<Stock> allStocksResponse = await _stockRepository.GetAllStocks(filter);

            // Map the response to StockDto
            IEnumerable<StockDto> allStocks = _mapper.Map<IEnumerable<Stock>, IEnumerable<StockDto>>(allStocksResponse);

            // Check if the stocks are empty
            if (!allStocks.Any())
            {
                return new StockResultDTO
                {
                    Status = true,
                    StatusCode = 404,
                    Message = "No stocks found",
                    Stocks = null
                };
            }

            // Return the stocks
            return new StockResultDTO
            {
                Status = true,
                StatusCode = 200,
                Message = "Stocks retrieved successfully",
                Stocks = allStocks
            };
        }
    }
}