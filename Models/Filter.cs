using Dotnet_Assessment.Enums;

namespace Dotnet_Assessment.Models
{
    public class Filter
    {
        public int MinBudget { get; set; }
        public int MaxBudget { get; set; }
        public List<FuelType>? FuelTypes { get; set; }
    }
}