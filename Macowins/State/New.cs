using Macowins.Domain;

namespace Macowins.State
{
    public class New : IState
    {
        public double GetPrice(Wear wear) => wear.BasePrice;
    }
}
