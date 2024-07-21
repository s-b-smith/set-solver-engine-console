using System.Reflection;
using static SetSolverEngineConsole.Constants.CardProps;

namespace SetSolverEngineConsole.Models
{
    public class Card(COLOR color, SHAPE shape, NUM num, SHADING shading)
    {
        public readonly COLOR color = color;
        public readonly SHAPE shape = shape;
        public readonly NUM num = num;
        public readonly SHADING shading = shading;

        public override string ToString()
        {
            FieldInfo[] fields = typeof(Card).GetFields();
            List<object> values = [];
            foreach (FieldInfo field in fields)
            {
                values.Add(field.GetValue(this)!);
            }

            return string.Join(", ", values);
        }

        public override bool Equals(object? obj)
        {
            return obj is Card card
                && color == card.color
                && shape == card.shape
                && num == card.num
                && shading == card.shading;
        }

        public override int GetHashCode()
        {
            int hash = 7;
            hash *= 7 * (int)color;
            hash *= 8 * (int)shape;
            hash *= 9 * (int)num;
            hash *= 11 * (int)shading;

            return hash;
        }
    }
}
