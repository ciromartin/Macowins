namespace Macowins.Payment
{
    public class CreditCard : IPayment
    {
        public string Name { get; }
        public int Fees { get; }
        public double Surcharge
        {
            get
            {
                {
                    return Fees switch
                    {
                        1 => 0,
                        2 => 0,
                        3 => 0,
                        4 => 1.1,
                        5 => 1.1,
                        6 => 1.1,
                        7 => 1.2,
                        8 => 1.2,
                        9 => 1.2,
                        10 => 1.25,
                        11 => 1.25,
                        12 => 1.25,
                        _ => 1.3,
                    };
                }
            }
        }

        public CreditCard(string name, int fees)
        {
            Name = name;
            Fees = fees;
        }

        public double GetPrice(double price, int quantity) => (Surcharge + (price * 0.01 * quantity)) * price;
    }
}
