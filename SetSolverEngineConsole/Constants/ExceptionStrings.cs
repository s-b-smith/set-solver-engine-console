using System.Diagnostics.CodeAnalysis;

namespace SetSolverEngineConsole.Constants
{
    public static class ExceptionStrings
    {
        public static string InvalidCardInput(string input)
        {
            return $"Invalid card input given: \"{input}\"";
        }

        [ExcludeFromCodeCoverage]
        public static string ArgumentError(string message)
        {
            return $"Argument Error: {message}";
        }

        [ExcludeFromCodeCoverage]
        public static string SystemError(string message)
        {
            return $"An unexpected error has occurred: {message}";
        }
    }
}
