using Macowins.Domain;

namespace Macowins.State
{
    public interface IState
    {
        double GetPrice(Wear wear);
    }
}