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
            const decimal originalPrice = 99;
            const decimal stateTax = 7.25m;
            const decimal priceTax = 7.1775m;
            const decimal finalNonRoundedPrice = 106.1775m;
            const decimal finalPrice = 106.18m;

            _priceHelper
                .Setup(x => x.CalculatePriceTax(originalPrice, stateTax))
                .Returns(priceTax);
            _priceHelper
                .Setup(x => x.CalculateFinalPrice(originalPrice, priceTax))
                .Returns(finalNonRoundedPrice);
            _priceHelper
                .Setup(x => x.RoundToTwoDecimals(finalNonRoundedPrice))
                .Returns(finalPrice);

            var price = _sut.GetFinalPrice(originalPrice, stateTax);

            Assert.That(price, Is.EqualTo(finalPrice));
        }
    }
}