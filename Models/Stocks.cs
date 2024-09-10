using Dotnet_Assessment.Enums;

namespace Dotnet_Assessment.Models
{
    public class Stock
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
    }
}