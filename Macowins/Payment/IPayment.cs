using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macowins.Domain;

namespace Macowins.Payment
{
    public interface IPayment
    {
        double GetPrice(Wear wear);
    }
}
