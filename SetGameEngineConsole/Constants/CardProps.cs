using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetSolverEngineConsole.Constants
{
    internal static class CardProps
    {
        public enum CardProp
        {
            COLOR,
            SHAPE,
            NUM,
            SHADING,
        };

        public enum COLOR 
        {
            RED,
            GREEN,
            PURPLE,
        };

        public enum SHAPE
        {
            CIRCLE,
            DIAMOND,
            SQUIGGLE,
        }

        public enum NUM
        {
            ONE,
            TWO,
            THREE,
        }

        public enum SHADING
        {
            EMPTY,
            SHADED,
            SOLID,
        }
    }
}
