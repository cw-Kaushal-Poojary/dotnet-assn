namespace Dotnet_Assessment.Utils
{
    public static class StockUtils
    {
        public static string GetCarName(int makeYear, string makeName, string modelName)
        {
            return $"{makeYear} {makeName} {modelName}";
        }

        public static bool IsValueForMoney(decimal price, int kms)
        {
            return price < 200000 && kms < 10000;
        }

        public static string FormatPrice(decimal price)
        {
            if (price >= 10000000) // 8 digits or more
            {
                return $"{price / 10000000.0m:0.##} Crores";
            }
            else if (price >= 100000) // 6 or 7 digits
            {
                return $"{price / 100000.0m:0.##} Lakhs";
            }
            else if (price >= 10000) // 5 digits
            {
                return $"{price / 1000.0m:0.##} Thousand";
            }
            else
            {
                return price.ToString(); // For prices less than 5 digits, return as is
            }
        }
    }
}