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
                // Check if minBudget is not greater than maxBudget
                if (minBudget.HasValue && maxBudget.HasValue && minBudget > maxBudget)
                {
                    return BadRequest(ResponseFormatter.FormatResponse(false, 400, null, "Min budget cannot be greater than max budget"));
                }

                IEnumerable<StockDto> result = await _stockService.GetStocks(minBudget, maxBudget, fuelIds);
                return Ok(ResponseFormatter.FormatResponse(true, 200, result, "Stocks retrieved successfully"));
            }
            catch (Exception e)
            {
                return StatusCode(500, ResponseFormatter.FormatResponse(false, 500, null, e.Message));
            }
        }
    }
}