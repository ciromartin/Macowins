using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Macowins.Domain;

namespace Macowins.Payment
{
    public class Cash : IPayment
    {
        public double GetPrice(double price) => price;
    }
}
