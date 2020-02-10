using System;

namespace PriceCalculator
{
    class Program
    {
       static void CalculateUsingChicagoStyle()
        {
            var priceCalculator = new ChicagoStyle.PriceCalculator();
            var finalPrice = priceCalculator.GetFinalPrice(100, 7.25m);
            Console.WriteLine($"ChicagoStyle -> Final price is: {finalPrice}");
        }

        static void CalculateUsingLondonStyle()
        {
            var priceHelper = new LondonStyle.PriceHelper();
            var priceCalculator = new LondonStyle.PriceCalculator(priceHelper);
            var finalPrice = priceCalculator.GetFinalPrice(100, 7.25m);
            Console.WriteLine($"LondonStyle -> Final price is: {finalPrice}");
        }

        static void Main(string[] args)
        {
            CalculateUsingChicagoStyle();
            CalculateUsingLondonStyle();
        }
    }
}
