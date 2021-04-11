using Macowins.Domain;

namespace Macowins.State
{
    public class Sale : IState
    {
        public double GetPrice(double basePrice) => basePrice * 0.5;
    }
}
