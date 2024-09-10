
namespace Dotnet_Assessment.Utils
{
    public static class FuelIdUtils
    {
        public static int[] GetUniqueFuelIds(string fuelIds)
        {
            if (string.IsNullOrEmpty(fuelIds))
            {
                return Array.Empty<int>(); // Return an empty array if input is null or empty
            }

            return fuelIds
                .Split(',')
                .Select(s => int.Parse(s.Trim()))
                .Distinct()
                .ToArray();
        }
    }
}