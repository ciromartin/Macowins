namespace Macowins.Payment
{
    public class Cash : IPayment
    {
        public double GetPrice(double price, int quantity) => price * quantity;
    }
}
