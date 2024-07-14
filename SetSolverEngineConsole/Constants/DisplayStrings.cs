using System.Text;

namespace SetSolverEngineConsole.Constants
{
    public static class DisplayStrings
    {
        public const string FINISHED_INPUT = "F";
        public const string HELP_INPUT = "H";
        public const string HELP_PROMPT = "Enter \"h\" for help";
        public const string PRESS_ANY_KEY_TO_CLOSE = "Press any key to close this window . . .";

        public const string TOO_MANY_CHARACTERS = "Too many characters";
        public const string ARE_YOU_MISSING_INPUT = "Are you missing input?";
        public const string NO_VALID_COLOR_GIVEN = "No valid color given";
        public const string NO_VALID_SHAPE_GIVEN = "No valid shape given";
        public const string NO_VALID_NUMBER_GIVEN = "No valid number given";
        public const string NO_VALID_SHADING_GIVEN = "No valid shading given";

        public static string getOpenTitle()
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

        public static string getPrompt()
        {
            return $"Enter card(s), or \"{FINISHED_INPUT}\" if finished:";
        }
    }
}
