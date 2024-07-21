using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
using SetSolverEngineConsole.Services;
using static SetSolverEngineConsole.Constants.DisplayStrings;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine(GetOpenTitle());
while (true)
{
    try
    {
        Console.Write(GetPrompt());
        string? input = Console.ReadLine()?.Trim();

        if (string.Equals(input, FINISHED_INPUT, StringComparison.OrdinalIgnoreCase))
        {
            break;
        }
        else if (input == null || input == string.Empty)
        {
            Console.WriteLine();
            Console.WriteLine(HELP_PROMPT);
            Console.WriteLine();
            continue;
        }
        else if (string.Equals(input, HELP_INPUT, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine();
            Console.WriteLine(GetHelp());
            Console.WriteLine();
            continue;
        }

        string[] rawCardInputs = input.Split(' ');
        if (rawCardInputs.Length > EngineParams.NUM_CARDS_IN_DECK) 
        {
            Console.WriteLine();
            Console.WriteLine(GetTooManyCardInputs());
            Console.WriteLine();
            continue;
        }

        HashSet<Card> cards = [];
        bool isInputsValid = true;
        foreach (string cardInput in rawCardInputs)
        {
            string validateMessage = InputService.ValidateCardInput(cardInput);
            if (validateMessage != string.Empty)
            {
                isInputsValid = false;
                Console.WriteLine();
                Console.WriteLine(validateMessage);
                break;
            }

            try
            {
                Card newCard = InputService.GetCardFromInput(cardInput.ToUpper());
                if (InputService.IsCardDuplicateInCollection(newCard, cards))
                {
                    isInputsValid = false;
                    Console.WriteLine();
                    Console.WriteLine(GetDisplayStringWithUserInput(DUPLICATE_CARD_FOUND, cardInput));
                    break;
                }

                cards.Add(newCard);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine();
                Console.WriteLine(ExceptionStrings.ArgumentError(e.Message));
                Console.Write(PRESS_ANY_KEY_TO_CLOSE);
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
        if (!isInputsValid)
        {
            Console.WriteLine(HELP_PROMPT);
            Console.WriteLine();
            continue;
        }

        var solveResult = SolverService.FindSets([.. cards]);
        Console.WriteLine();
        Console.WriteLine(solveResult.ToString());
        Console.WriteLine();
    } 
    catch (Exception e)
    {
        Console.WriteLine();
        Console.WriteLine(ExceptionStrings.SystemError(e.Message));
        Console.Write(PRESS_ANY_KEY_TO_CLOSE);
        Console.ReadKey();
        Environment.Exit(0);
    }
}