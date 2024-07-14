using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
using SetSolverEngineConsole.Services;

var inputService = new InputService();
var solverService = new SolverService();

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine(DisplayStrings.GetOpenTitle());
while (true)
{
    try
    {
        Console.WriteLine(DisplayStrings.GetPrompt());
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
            Console.WriteLine();
            Console.WriteLine(DisplayStrings.GetHelp());
            Console.WriteLine();
            continue;
        }

        string[] rawCardInputs = input.Split(' ');
        if (rawCardInputs.Length > 100) 
        {
            Console.WriteLine();
            Console.WriteLine(DisplayStrings.TOO_MANY_CARD_INPUTS);
            Console.WriteLine();
            continue;
        }

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