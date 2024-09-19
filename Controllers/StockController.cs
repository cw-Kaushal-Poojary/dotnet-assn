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
        private readonly IStockLogic _stockLogic;

        public StockController(IStockLogic stockLogic)
        {
            _stockLogic = stockLogic;
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

                StockResultDTO result = await _stockLogic.GetStocks(requestDto);
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