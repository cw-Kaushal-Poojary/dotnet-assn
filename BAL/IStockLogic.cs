using Dotnet_Assessment.DTO;

namespace Dotnet_Assessment.BAL
{
    public interface IStockLogic
    {
        public Task<StockResultDTO> GetStocks(RequestDto requestDto);
    }
}