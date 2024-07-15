namespace SetSolverEngineConsole.Constants
{
    public static class CardProps
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
            RED = 'R',
            GREEN = 'G',
            PURPLE = 'P',
        };

        public enum SHAPE
        {
            CIRCLE = 'C',
            DIAMOND = 'D',
            SQUIGGLE = 'Q',
        }

        public enum NUM
        {
            ONE = '1',
            TWO = '2',
            THREE = '3',
        }

        public enum SHADING
        {
            EMPTY = 'E',
            STRIPED = 'T',
            SOLID = 'S',
        }
    }
}
