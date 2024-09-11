using Dotnet_Assessment.BAL;
using Dotnet_Assessment.DTO;
using Dotnet_Assessment.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet_Assessment.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet]
        [Route("get-stocks")]
        public async Task<IActionResult> GetStocks(int? minBudget, int? maxBudget, string? fuelIds)
        {
            try
            {
                RequestDto requestDto = new()
                {
                    MinBudget = minBudget,
                    MaxBudget = maxBudget,
                    FuelIds = fuelIds
                };

                StockResultDTO result = await _stockService.GetStocks(requestDto);
                return StatusCode(result.StatusCode, ResponseFormatter.FormatResponse(
                    result.Status,
                    result.StatusCode,
                    result.Stocks,
                    result.Message
                ));
            }
            catch (Exception e)
            {
                return StatusCode(500, ResponseFormatter.FormatResponse(false, 500, null, e.Message));
            }
        }
    }
}