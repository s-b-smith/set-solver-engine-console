using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
using System.Text.RegularExpressions;
using static SetSolverEngineConsole.Constants.DisplayStrings;

namespace SetSolverEngineConsole.Services
{
    public static partial class InputService
    {
        public static string ValidateCardInput(string cardInput)
        {
            if (cardInput.Length != CardProps.NumCardProps)
            {
                if (cardInput.Length > CardProps.NumCardProps)
                {
                    return GetDisplayStringWithUserInput(TOO_MANY_CHARACTERS, cardInput);
                }
                else
                {
                    return GetDisplayStringWithUserInput(ARE_YOU_MISSING_INPUT, cardInput);
                }
            }

            Regex colorRegex = ColorInputRegex();
            Regex shapeRegex = ShapeInputRegex();
            Regex numRegex = NumInputRegex();
            Regex shadingRegex = ShadingInputRegex();

            if (!colorRegex.IsMatch(cardInput))
            {
                return GetDisplayStringWithUserInput(NO_VALID_COLOR_GIVEN, cardInput); ;
            }
            else if (!shapeRegex.IsMatch(cardInput))
            {
                return GetDisplayStringWithUserInput(NO_VALID_SHAPE_GIVEN, cardInput); ;
            }
            else if (!numRegex.IsMatch(cardInput))
            {
                return GetDisplayStringWithUserInput(NO_VALID_NUMBER_GIVEN, cardInput); ;
            }
            else if (!shadingRegex.IsMatch(cardInput))
            {
                return GetDisplayStringWithUserInput(NO_VALID_SHADING_GIVEN, cardInput); ;
            }

            return string.Empty;
        }

        public static Card GetCardFromInput(string cardInput)
        {
            if (cardInput.Length != CardProps.NumCardProps)
            {
                throw new ArgumentException(ExceptionStrings.InvalidCardInput(cardInput));
            }

            CardProps.COLOR? color = null;
            CardProps.SHAPE? shape = null;
            CardProps.NUM? num = null;
            CardProps.SHADING? shading = null;

            foreach (char cardProp in cardInput)
            {
                if (Enum.IsDefined((CardProps.COLOR)cardProp))
                {
                    color = (CardProps.COLOR)cardProp;
                }
                else if (Enum.IsDefined((CardProps.SHAPE)cardProp))
                {
                    shape = (CardProps.SHAPE)cardProp;
                }
                else if (Enum.IsDefined((CardProps.NUM)cardProp))
                {
                    num = (CardProps.NUM)cardProp;
                }
                else if (Enum.IsDefined((CardProps.SHADING)cardProp))
                {
                    shading = (CardProps.SHADING)cardProp;
                }
                else
                {
                    throw new ArgumentException(ExceptionStrings.InvalidCardInput(cardInput));
                }
            }

            if (color == null || shape == null || num == null || shading == null)
            {
                throw new ArgumentException(ExceptionStrings.InvalidCardInput(cardInput));
            }

            return new Card(
                (CardProps.COLOR)color, 
                (CardProps.SHAPE)shape, 
                (CardProps.NUM)num, 
                (CardProps.SHADING)shading);
        }

        public static bool IsCardDuplicateInCollection(Card card, ICollection<Card> collection)
        {
            return collection.Contains(card);
        }
    }

    public static partial class InputService
    {
        [GeneratedRegex(@"R|G|P", RegexOptions.IgnoreCase, "en-US")]    // Red, Green, Purple
        private static partial Regex ColorInputRegex();
        [GeneratedRegex(@"C|D|Q", RegexOptions.IgnoreCase, "en-US")]    // Circle, Diamond, S(q)uiggle
        private static partial Regex ShapeInputRegex();
        [GeneratedRegex(@"[1-3]", RegexOptions.None, "en-US")]          // One, Two, Three
        private static partial Regex NumInputRegex();
        [GeneratedRegex(@"S|T|E", RegexOptions.IgnoreCase, "en-US")]    // Solid, S(t)riped, Empty
        private static partial Regex ShadingInputRegex();
    }
}
