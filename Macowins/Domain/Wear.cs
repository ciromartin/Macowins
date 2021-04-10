using Macowins.State;

namespace Macowins.Domain
{
    public class Wear
    {
        public string Name { get; }
        public IState State { get; private set; }
        public double BasePrice { get; }

        public Wear(string name, double basePrice)
        {
            this.Name = name;
            this.BasePrice = basePrice;
            this.State = new New();
        }

        public Wear(string name, double basePrice, IState state)
        {
            this.Name = name;
            this.BasePrice = basePrice;
            this.State = state;
        }

        public void SetState(IState state) => State = state;

        public double GetPrice() => State.GetPrice(this);
    }
}
