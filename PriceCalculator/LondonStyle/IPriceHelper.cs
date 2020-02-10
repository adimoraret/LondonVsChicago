namespace PriceCalculator.LondonStyle
{
    public interface IPriceHelper
    {
        decimal CalculatePriceTax(decimal originalPrice, decimal stateTax);
        decimal CalculateFinalPrice(decimal originalPrice, decimal priceTax);
        decimal RoundToTwoDecimals(decimal price);
    }
}