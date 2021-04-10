using FluentAssertions;
using Macowins.Domain;
using Macowins.State;
using Xunit;

namespace Macowins.Test
{
    public class WearTest
    {
        [Theory]
        [InlineData("Pantalon", 300)]
        [InlineData("Saco", 400)]
        [InlineData("Camisa", 250)]
        public void Wear_ShouldBeNewState_WhenIsInitialized(string name, double basePrice)
        {
            //Arrange
            //Act
            var wear = new Wear(name, basePrice);

            //Assert
            wear.Name.Should().Be(name);
            wear.BasePrice.Should().Be(basePrice);
            wear.State.Should().BeOfType<New>();
        }

        [Theory]
        [InlineData("Pantalon", 300)]
        [InlineData("Saco", 400)]
        [InlineData("Camisa", 250)]
        public void Wear_ShouldBeBasePriceEqualToFinalPrice_WhenIsNewState(string name, double basePrice)
        {
            //Arrange
            //Act
            var wear = new Wear(name, basePrice);

            //Assert
            wear.GetPrice().Should().Be(basePrice);
        }


        [Theory]
        [InlineData("Pantalon", 300, 100, 200)]
        [InlineData("Pantalon", 300, 110, 190)]
        [InlineData("Pantalon", 300, 140,160)]
        [InlineData("Saco", 400, 200,200)]
        [InlineData("Saco", 400, 150, 250)]
        [InlineData("Camisa", 250, 50, 200)]
        [InlineData("Camisa", 250, 70, 180)]
        public void Wear_ShouldBeBasePriceLessDiscount_WhenIsPromotionState(
            string name, 
            double basePrice,
            double discount, 
            double finalPrice)
        {
            //Arrange
            //Act
            var promotion = new Promotion(discount);
            var wear = new Wear(name, basePrice, promotion);

            //Assert
            wear.GetPrice().Should().Be(finalPrice);
        }


        [Theory]
        [InlineData("Pantalon", 300, 150)]
        [InlineData("Saco", 400, 200)]
        [InlineData("Camisa", 250, 125)]
        public void Wear_ShouldBeHalfBasePrice_WhenIsSaleState(
            string name,
            double basePrice,
            double finalPrice)
        {
            //Arrange
            //Act
            var sale = new Sale();
            var wear = new Wear(name, basePrice, sale);

            //Assert
            wear.GetPrice().Should().Be(finalPrice);
        }

        [Theory]
        [InlineData("Pantalon", 300, 150)]
        [InlineData("Saco", 400, 200)]
        [InlineData("Camisa", 250, 125)]
        public void Wear_ShouldBeHalfBasePrice_WhenIsSetSaleState(
            string name,
            double basePrice,
            double finalPrice)
        {
            //Arrange
            var sale = new Sale();
            var wear = new Wear(name, basePrice);

            //Act
            wear.SetState(sale);

            //Assert
            wear.GetPrice().Should().Be(finalPrice);
        }

        [Theory]
        [InlineData("Pantalon", 300, 100, 200)]
        [InlineData("Pantalon", 300, 110, 190)]
        [InlineData("Pantalon", 300, 140, 160)]
        [InlineData("Saco", 400, 200, 200)]
        [InlineData("Saco", 400, 150, 250)]
        [InlineData("Camisa", 250, 50, 200)]
        [InlineData("Camisa", 250, 70, 180)]
        public void Wear_ShouldBeBasePriceLessDiscount_WhenIsSetPromotionState(
            string name,
            double basePrice,
            double discount,
            double finalPrice)
        {
            //Arrange
            var promotion = new Promotion(discount);
            var wear = new Wear(name, basePrice);

            //Act
            wear.SetState(promotion);

            //Assert
            wear.GetPrice().Should().Be(finalPrice);
        }
    }
}