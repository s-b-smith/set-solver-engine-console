using SetSolverEngineConsole.Models;

namespace SetSolverEngineConsole.Services
{
    public class InputService
    {
        public Card readCard(string input)
        {
            throw new NotImplementedException();
        }

        private string validateCardInput(string cardInput)
        {
            if (cardInput.Length != 4)
            {
                if (cardInput.Length > 4)
                {
                    return "Too many characters!";
                }
                else
                {
                    return "Are you missing input?";
                }
            }

            // TODO: Check that one of each props is listed
            // Remember that you want them to enter as many cards as they want (within reason)
            // Space-separated

            throw new NotImplementedException();
        }
    }
}
