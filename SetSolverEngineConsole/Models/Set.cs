namespace SetSolverEngineConsole.Models
{
    public class Set(Card card1, Card card2, Card card3)
    {
        public readonly Card card1 = card1;
        public readonly Card card2 = card2;
        public readonly Card card3 = card3;
        public readonly HashSet<Card> cards = [card1, card2, card3];

        public override string ToString()
        {
            return "Card 1: " + card1.ToString() + "\n"
                + "Card 2: " + card2.ToString() + "\n"
                + "Card 3: " + card3.ToString();
        }

        public override bool Equals(object? obj)
        {
            return obj is Set set
                && set.cards.SetEquals(cards);
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash *= 7 * card1.GetHashCode();
            hash *= 8 * card2.GetHashCode();
            hash *= 9 * card3.GetHashCode();

            return hash;
        }
    }
}
