using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
using SetSolverEngineConsole.Services;

var inputService = new InputService();
var solverService = new SolverService();

Console.WriteLine(DisplayStrings.getOpenTitle());
while (true)
{
    try
    {
        Console.WriteLine(DisplayStrings.getPrompt());
        string? input = Console.ReadLine()?.Trim();

        if (input == null || input == "")
        {
            Console.WriteLine(DisplayStrings.HELP_PROMPT);
            Console.WriteLine();
            continue;
        }
        else if (string.Equals(input, DisplayStrings.FINISHED_INPUT, StringComparison.OrdinalIgnoreCase))
        {
            break;
        }
        else if (string.Equals(input, DisplayStrings.HELP_INPUT, StringComparison.OrdinalIgnoreCase))
        {
            // TODO: Write help info
            continue;
        }

        string[] rawCardInputs = input.Split(' ');
        List<Card> cards = [];
        bool isCardsValidated = true;
        foreach (string cardInput in rawCardInputs)
        {
            string validateMessage = inputService.ValidateCardInput(cardInput);
            if (validateMessage != "")
            {
                isCardsValidated = false;
                Console.WriteLine();
                Console.WriteLine(validateMessage);
                break;
            }

            try
            {
                cards.Add(inputService.GetCardFromInput(cardInput.ToUpper()));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine();
                Console.WriteLine(ExceptionStrings.ArgumentError(e.Message));
                Console.Write(DisplayStrings.PRESS_ANY_KEY_TO_CLOSE);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        if (!isCardsValidated)
        {
            Console.WriteLine(DisplayStrings.HELP_PROMPT);
            Console.WriteLine();
            continue;
        }

        var solveResult = solverService.FindSets([.. cards]);
        Console.WriteLine();
        Console.WriteLine(solveResult.ToString());
        Console.WriteLine();
    } 
    catch (Exception e)
    {
        Console.WriteLine();
        Console.WriteLine(ExceptionStrings.SystemError(e.Message));
        Console.Write(DisplayStrings.PRESS_ANY_KEY_TO_CLOSE);
        Console.ReadKey();
        Environment.Exit(0);
    }
}