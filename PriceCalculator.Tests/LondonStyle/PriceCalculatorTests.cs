using Moq;
using NUnit.Framework;
using PriceCalculator.LondonStyle;

namespace PriceCalculator.Tests.LondonStyle
{
    public class PriceCalculatorTests
    {
        private Mock<IPriceHelper> _priceHelper;
        private PriceCalculator.LondonStyle.PriceCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _priceHelper = new Mock<IPriceHelper>(MockBehavior.Strict);
            _sut = new PriceCalculator.LondonStyle.PriceCalculator(_priceHelper.Object);
        }

        [Test]
        public void ShouldCalculateFinalPrice()
        {
            var originalPrice = 99;
            var stateTax = 7.25m;
            var priceTax = 7.1775m;
            var finalNonRoundedPrice = 106.1775m;
            var finalPrice = 106.18m;

            _priceHelper
                .Setup(x => x.CalculatePriceTax(originalPrice, stateTax))
                .Returns(priceTax);
            _priceHelper
                .Setup(x => x.CalalculateFinalPrice(originalPrice, priceTax))
                .Returns(finalNonRoundedPrice);
            _priceHelper
                .Setup(x => x.RoundToTwoDecimals(finalNonRoundedPrice))
                .Returns(finalPrice);

            var price = _sut.GetFinalPrice(originalPrice, stateTax);

            Assert.That(price, Is.EqualTo(finalPrice));
        }
    }
}