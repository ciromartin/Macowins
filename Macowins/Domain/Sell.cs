using System;
using Macowins.Payment;

namespace Macowins.Domain
{
    public class Sell
    {
        public int Quantity { get; set; }
        public Wear Wear { get; set; }
        public DateTime Date { get; set; }
        public IPayment Payment { get; set; }

        public Sell(DateTime date, int quantity, Wear wear, IPayment payment)
        {
            Date = date;
            Quantity = quantity;
            Wear = wear;
            Payment = payment;
        }

        public double GetTotal()
        {
            return Quantity * Payment.GetPrice(Wear.GetPrice(), Quantity);
        }
    }
}
