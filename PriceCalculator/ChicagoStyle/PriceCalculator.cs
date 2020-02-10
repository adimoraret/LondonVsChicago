using System;

namespace PriceCalculator.ChicagoStyle
{
    public class PriceCalculator
    {
        public decimal GetFinalPrice(decimal originalPrice, decimal stateTax)
        {
            return Math.Round(originalPrice + originalPrice * stateTax / 100, 2, MidpointRounding.AwayFromZero);
        }
    }
}