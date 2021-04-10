using Macowins.Domain;

namespace Macowins.State
{
    public class Sale : IState
    {
        public double GetPrice(Wear wear) => wear.BasePrice * 0.5;
    }
}
