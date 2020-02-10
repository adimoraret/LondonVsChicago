using System;

namespace PriceCalculator.LondonStyle
{
    public class PriceCalculator
    {
        private IPriceHelper _priceHelper;

        public PriceCalculator(IPriceHelper priceHelper)
        {
            _priceHelper = priceHelper;
        }
        public decimal GetFinalPrice(decimal originalPrice, decimal stateTax)
        {
           var priceTax = _priceHelper.CalculatePriceTax(originalPrice, stateTax);
           var finalPrice = _priceHelper.CalalculateFinalPrice(originalPrice, priceTax);
           return _priceHelper.RoundToTwoDecimals(finalPrice);
        }
    }
}