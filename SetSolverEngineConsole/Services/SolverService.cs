using SetSolverEngineConsole.Models;
using static SetSolverEngineConsole.Constants.CardProps;

namespace SetSolverEngineConsole.Services
{
    public static class SolverService
    {
        public static SetSolverResult FindSets(Card[] cards)
        {
            List<Set> sets = [];
            for (int i = 0; i < cards.Length - 2; i++)
            {
                for (int j = i + 1; j < cards.Length - 1; j++)
                {
                    for (int k = j + 1; k < cards.Length; k++)
                    {
                        Card card1 = cards[i];
                        Card card2 = cards[j];
                        Card card3 = cards[k];
                        Set set = new(card1, card2, card3);
                        if (CheckAllProps(set))
                        {
                            sets.Add(set);
                        }
                    }
                }
            }

            return new SetSolverResult(sets.Count, [.. sets]);
        }

        private static bool CheckAllProps(Set set)
        {
            foreach (CardProp prop in Enum.GetValues(typeof(CardProp)))
            {
                if (!IsPropAllSame(set, prop) && !IsPropAllDifferent(set, prop))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool IsPropAllSame(Set set, CardProp prop)
        {
            switch (prop)
            {
                case CardProp.COLOR:
                    return set.card1.color.Equals(set.card2.color) && set.card1.color.Equals(set.card3.color);
                case CardProp.SHAPE:
                    return set.card1.shape.Equals(set.card2.shape) && set.card1.shape.Equals(set.card3.shape);
                case CardProp.NUM:
                    return set.card1.num.Equals(set.card2.num) && set.card1.num.Equals(set.card3.num);
                case CardProp.SHADING:
                    return set.card1.shading.Equals(set.card2.shading) && set.card1.shading.Equals(set.card3.shading);
                default:
                    break;
            }

            return false;
        }

        private static bool IsPropAllDifferent(Set set, CardProp prop)
        {
            switch (prop)
            {
                case CardProp.COLOR:
                    return !set.card1.color.Equals(set.card2.color) && !set.card1.color.Equals(set.card3.color)
                        && !set.card2.color.Equals(set.card3.color);
                case CardProp.SHAPE:
                    return !set.card1.shape.Equals(set.card2.shape) && !set.card1.shape.Equals(set.card3.shape)
                        && !set.card2.shape.Equals(set.card3.shape);
                case CardProp.NUM:
                    return !set.card1.num.Equals(set.card2.num) && !set.card1.num.Equals(set.card3.num)
                        && !set.card2.num.Equals(set.card3.num);
                case CardProp.SHADING:
                    return !set.card1.shading.Equals(set.card2.shading) && !set.card1.shading.Equals(set.card3.shading)
                        && !set.card2.shading.Equals(set.card3.shading);
                default:
                    break;
            }

            return false;
        }
    }
}
