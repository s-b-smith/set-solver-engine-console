using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetSolverEngineConsole.Models
{
    public class Set(Card card1, Card card2, Card card3)
    {
        public readonly Card card1 = card1;
        public readonly Card card2 = card2;
        public readonly Card card3 = card3;

        public override string ToString()
        {
            return "Card 1: " + card1.ToString() + "\n"
                + "Card 2: " + card2.ToString() + "\n"
                + "Card 3: " + card3.ToString();
        }
    }
}
