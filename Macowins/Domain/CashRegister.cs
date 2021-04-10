using System;
using System.Collections.Generic;

namespace Macowins.Domain
{
    public class CashRegister
    {
        public DateTime Date { get; }
        public List<Sell> Sells { get; }

        public CashRegister(DateTime date)
        {
            Date = date;
            Sells = new List<Sell>();
        }

        public void AddSell(Sell sell)
        {
            Sells.Add(sell);
        }

        public double GetTotal()
        {
            double total = 0;
            Sells.ForEach(s => total += s.GetTotal());
            return total;
        }

    }
}
