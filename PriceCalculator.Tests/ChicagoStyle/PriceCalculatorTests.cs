using NUnit.Framework;

namespace PriceCalculator.Tests.ChicagoStyle
{
    public class PriceCalculatorTests
    {
        private PriceCalculator.ChicagoStyle.PriceCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new PriceCalculator.ChicagoStyle.PriceCalculator();
        }

        [TestCase(100, 7.25, 107.25)]
        public void ShouldCalculateFinalPrice(decimal price, decimal stateTax, decimal expectedFinalPrice)
        {
            var finalPrice = _sut.GetFinalPrice(100, 7.25m);

            Assert.That(finalPrice, Is.EqualTo(expectedFinalPrice));
        }
    }
}