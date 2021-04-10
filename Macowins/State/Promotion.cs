using Macowins.Domain;

namespace Macowins.State
{
    public class Promotion : IState
    {
        public double Discount { get;private set; }
        public Promotion(double discount) => this.Discount = discount;
        public double GetPrice(Wear wear) => wear.BasePrice - this.Discount;
    }
}
