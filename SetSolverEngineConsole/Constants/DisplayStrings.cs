using System.Net;
using System.Text;

namespace SetSolverEngineConsole.Constants
{
    public static class DisplayStrings
    {
        public const string FINISHED_INPUT = "F";
        public const string HELP_INPUT = "H";
        public const string HELP_PROMPT = "Enter \"h\" for help";
        public const string TOO_MANY_CARD_INPUTS = "Please enter only 100 cards at a time";
        public const string PRESS_ANY_KEY_TO_CLOSE = "Press any key to close this window . . .";

        public const string TOO_MANY_CHARACTERS = "Too many characters";
        public const string ARE_YOU_MISSING_INPUT = "Are you missing input?";
        public const string NO_VALID_COLOR_GIVEN = "No valid color given";
        public const string NO_VALID_SHAPE_GIVEN = "No valid shape given";
        public const string NO_VALID_NUMBER_GIVEN = "No valid number given";
        public const string NO_VALID_SHADING_GIVEN = "No valid shading given";

        public static string GetOpenTitle()
        {
            StringBuilder sb = new();

            sb.AppendLine("|||||||||||||||||||");
            sb.AppendLine("|||||||||||||||||||");
            sb.AppendLine("|||||-- SET --|||||");
            sb.AppendLine("||||-- SOLVER --|||");
            sb.AppendLine("|||||||||||||||||||");
            sb.AppendLine("|||||||||||||||||||");
            sb.AppendLine();
            sb.AppendLine("*******************");
            sb.AppendLine();
            sb.AppendLine("WELCOME!");
            sb.AppendLine();
            sb.AppendLine(HELP_PROMPT);

            return sb.ToString();
        }

        public static string GetPrompt()
        {
            return $"Enter card(s), or \"{FINISHED_INPUT}\" if finished:";
        }

        public static string GetHelp()
        {
            var copyrightSymbol = WebUtility.HtmlDecode("&copy;");
            StringBuilder sb = new();

            sb.AppendLine($"Each Set\u00a9 card can be described with 4 properties:");
            sb.AppendLine("1. Shape");
            sb.AppendLine("2. Color");
            sb.AppendLine("3. Number of shapes");
            sb.AppendLine("4. Shading");
            sb.AppendLine();
            sb.AppendLine("The Set Solver can take any number of cards (maximum 100) and calculate " +
                "each possible set that can be formed.");
            sb.AppendLine("To enter the cards, each property above must be given for each card. The " +
                "properties are encoded as follows:");
            sb.AppendLine();
            sb.AppendLine("SHAPE");
            sb.AppendLine("1. Circle = \"C\"");
            sb.AppendLine("2. Diamond = \"D\"");
            sb.AppendLine("3. S(q)uiggle = \"Q\"");
            sb.AppendLine();
            sb.AppendLine("COLOR");
            sb.AppendLine("1. Red = \"R\"");
            sb.AppendLine("2. Green = \"G\"");
            sb.AppendLine("3. Purple = \"P\"");
            sb.AppendLine();
            sb.AppendLine("NUMBER");
            sb.AppendLine("1. One = \"1\"");
            sb.AppendLine("2. Two = \"2\"");
            sb.AppendLine("3. Three = \"3\"");
            sb.AppendLine();
            sb.AppendLine("SHADING");
            sb.AppendLine("1. Empty = \"E\"");
            sb.AppendLine("2. S(t)riped = \"T\"");
            sb.AppendLine("3. Solid = \"S\"");
            sb.AppendLine();
            sb.AppendLine("For each card you may enter these properties in any order you like. " +
                "Letters may be upper or lower case.");
            sb.AppendLine();
            sb.AppendLine("EXAMPLES");
            sb.AppendLine();
            sb.AppendLine("3 cards:");
            sb.AppendLine("CR1E CR1T CR1S"); 
            sb.AppendLine("(Circle, Red, One, Empty), (Circle, Red, One, Striped), (Circle, Red, One, Solid)");
            sb.AppendLine();
            sb.AppendLine("12 cards:");
            sb.AppendLine("GD3S RD3E PQ3E RD1E GC3E PD2S PC2E PD1E RD1T RQ2S GC2T PD1T");
            sb.AppendLine("(Green, Diamond, Three, Solid), (Red, Diamond, Three, Empty), " +
                " (Purple, Squiggle, Three, Empty)");
            sb.AppendLine("(Red, Diamond, One, Empty),     (Green, Circle, Three, Empty), " +
                "(Purple, Diamond, Two, Solid)");
            sb.AppendLine("(Purple, Circle, Two, Empty),   (Purple, Diamond, One, Empty), " +
                "(Red, Diamond, One, Striped)");
            sb.Append("(Red, Squiggle, Two, Solid),    (Green, Circle, Two, Striped), " +
                "(Purple, Diamond, One, Striped)");

            return sb.ToString();
        }
    }
}
