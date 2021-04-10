using System;
using FluentAssertions;
using Macowins.Domain;
using Macowins.Payment;
using Xunit;

namespace Macowins.Test
{
    public class SellTest
    {
        [Fact]
        public void Wear_ShouldBeSuccess_WhenIsInitialized()
        {
            //Arrange
            var date = DateTime.Now;
            var quantity = 1;
            var wear = new Wear("Pantalon", 300);
            var payment = new Cash();

            //Act
            var sell = new Sell(date, quantity, wear, payment);

            //Assert
            sell.Quantity.Should().Be(quantity);
            sell.Date.Should().Be(date);
            sell.Wear.Should().BeOfType<Wear>();
            sell.Payment.Should().BeOfType<Cash>();
        }

        [Theory]
        [InlineData("Pantalon", 300, 1, 300)]
        [InlineData("Pantalon", 300, 2, 600)]
        [InlineData("Pantalon", 400, 3, 1200)]
        public void Wear_ShouldBeBasePriceMultiplyByQuantity_WhenIsCashPaymentAndNewWearState(
            string name, 
            double basePrice,
            int quantity, 
            double totalPrice)
        {
            //Arrange
            var date = DateTime.Now;
            var wear = new Wear(name, basePrice);
            var payment = new Cash();
            var sell = new Sell(date, quantity, wear, payment);

            //Act
            var total = sell.GetTotal();
            
            //Assert
            total.Should().Be(totalPrice);
        }

        [Theory]
        [InlineData("Pantalon", 300, 1, 300)]
        [InlineData("Pantalon", 300, 2, 600)]
        [InlineData("Pantalon", 400, 3, 1200)]
        public void Wear_ShouldBeSurchargesTheBasePrice_WhenIsCreditCardAndNewWearState(
            string name,
            double basePrice,
            int quantity,
            double totalPrice)
        {
            //Arrange
            var date = DateTime.Now;
            var wear = new Wear(name, basePrice);
            var payment = new Cash();
            var sell = new Sell(date, quantity, wear, payment);

            //Act
            var total = sell.GetTotal();

            //Assert
            total.Should().Be(totalPrice);
        }
    }
}
