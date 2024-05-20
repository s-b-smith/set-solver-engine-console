using SetSolverEngineConsole.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SetSolverEngineConsole.Models
{
    public class Card(CardProps.COLOR color, CardProps.SHAPE shape, CardProps.NUM num, CardProps.SHADING shading)
    {
        public readonly CardProps.COLOR color = color;
        public readonly CardProps.SHAPE shape = shape;
        public readonly CardProps.NUM num = num;
        public readonly CardProps.SHADING shading = shading;

        public override string ToString()
        {
            FieldInfo[] fields = typeof(Card).GetFields();
            List<object> values = [];
            foreach (FieldInfo field in fields)
            {
                values.Add(field.GetValue(this));
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
