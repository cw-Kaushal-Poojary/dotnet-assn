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
            decimal value;
            string unit;

            if (price >= 10000000) // 8 digits or more
            {
                value = price / 10000000.0m;
                unit = (value == 1) ? "Crore" : "Crores";
            }
            else if (price >= 100000) // 6 or 7 digits
            {
                value = price / 100000.0m;
                unit = (value == 1) ? "Lakh" : "Lakhs";
            }
            else if (price >= 1000) // 5 digits
            {
                value = price / 1000.0m;
                unit = (value == 1) ? "Thousand" : "Thousands";
            }
            else
            {
                value = price;
                unit = "";
            }

            return $"Rs. {value} {unit}";
        }
    }
}