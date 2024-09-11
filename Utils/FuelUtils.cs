using Dotnet_Assessment.Enums;

namespace Dotnet_Assessment.Utils
{
    public static class FuelIdUtils
    {
        public static List<FuelType> GetUniqueFuelIds(string? fuelIds)
        {
            if (string.IsNullOrEmpty(fuelIds))
            {
                return new List<FuelType>(); // Return an empty array if input is null or empty
            }

            return fuelIds
                .Split('+')
                .Select(fuelId => (FuelType)int.Parse(fuelId.Trim()))
                .Distinct()
                .ToList();
        }
    }
}