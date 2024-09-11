using Dotnet_Assessment.Enums;

namespace Dotnet_Assessment.DTO
{
    public class StockDto
    {
        public int Id { get; set; }
        public int MakeYear { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public decimal Price { get; set; }
        public int Km { get; set; }
        public FuelType FuelType { get; set; }
        public string Image { get; set; }
        public string City { get; set; }
        public string FormattedPrice { get; set; }
        public string CarName { get; set; }
        public bool IsValueForMoney { get; set; }
    }

    public class StockResultDTO 
    {
        public IEnumerable<StockDto>? Stocks { get; set; }
        public int StatusCode { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }
    }
}