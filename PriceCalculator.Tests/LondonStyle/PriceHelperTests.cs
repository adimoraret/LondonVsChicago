using NUnit.Framework;
using PriceCalculator.LondonStyle;

namespace PriceCalculator.Tests.LondonStyle
{
    public class PriceHelperTests
    {
        private PriceCalculator.LondonStyle.IPriceHelper _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new PriceHelper();
        }

        [TestCase(0, 7.25, 0)]
        [TestCase(10, 7.25, 0.725)]
        [TestCase(100, 7.25, 7.25)]
        [TestCase(99, 7.25, 7.1775)]
        public void ShouldCalculatePriceTax(decimal price, decimal stateTax, decimal expectedPriceTax)
        {
           var priceTax = _sut.CalculatePriceTax(price, stateTax);
           
           Assert.That(priceTax, Is.EqualTo(expectedPriceTax));
        }

        [TestCase(0, 0)]
        [TestCase(10, 1)]
        [TestCase(20, 2)]
        public void ShouldCalculateFinalPrice(decimal originalPrice, decimal priceTax)
        {
            var finalPrice = _sut.CalalculateFinalPrice(originalPrice, priceTax);

            Assert.That(finalPrice, Is.EqualTo(originalPrice + priceTax));
        }

        [TestCase(0, 0)]
        [TestCase(10.50, 10.50)]
        [TestCase(20.544, 20.54)]
        [TestCase(20.549, 20.55)]
        [TestCase(20.545, 20.55)]
        public void ShouldRoundPriceToTwoDecimals(decimal price, decimal expectedPrice)
        {
            var roundedPrice = _sut.RoundToTwoDecimals(price);

            Assert.That(roundedPrice, Is.EqualTo(expectedPrice));
        }
    }
}