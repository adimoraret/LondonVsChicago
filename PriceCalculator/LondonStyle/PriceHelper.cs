using System;
namespace PriceCalculator.LondonStyle
{
    public class PriceHelper : IPriceHelper
    {
        public decimal CalculatePriceTax(decimal originalPrice, decimal stateTax)
        {
            return originalPrice * stateTax / 100;
        }

        public decimal CalculateFinalPrice(decimal originalPrice, decimal priceTax)
        {
            return originalPrice + priceTax;
        }

        public decimal RoundToTwoDecimals(decimal price)
        {
            return Math.Round(price, 2, MidpointRounding.AwayFromZero);
        }
    }
}