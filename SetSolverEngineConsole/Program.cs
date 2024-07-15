using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
using SetSolverEngineConsole.Services;

// TODO: Prevent duplicates from being entered
var inputService = new InputService();
var solverService = new SolverService();

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine(DisplayStrings.GetOpenTitle());
while (true)
{
    try
    {
        Console.Write(DisplayStrings.GetPrompt());
        string? input = Console.ReadLine()?.Trim();

        if (input == null || input == "")
        {
            Console.WriteLine();
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
        if (rawCardInputs.Length > EngineParams.NUM_CARDS_IN_DECK) 
        {
            Console.WriteLine();
            Console.WriteLine(DisplayStrings.GetTooManyCardInputs());
            Console.WriteLine();
            continue;
        }

        List<Card> cards = [];
        bool isInputsValid = true;
        foreach (string cardInput in rawCardInputs)
        {
            string validateMessage = inputService.ValidateCardInput(cardInput);
            if (validateMessage != "")
            {
                isInputsValid = false;
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
        if (!isInputsValid)
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