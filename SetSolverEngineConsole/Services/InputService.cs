using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
using System.Text.RegularExpressions;

namespace SetSolverEngineConsole.Services
{
    public partial class InputService
    {
        public string ValidateCardInput(string cardInput)
        {
            if (cardInput.Length != 4)
            {
                if (cardInput.Length > 4)
                {
                    return DisplayStrings.TOO_MANY_CHARACTERS;
                }
                else
                {
                    return DisplayStrings.ARE_YOU_MISSING_INPUT;
                }
            }

            Regex colorRegex = ColorInputRegex();
            Regex shapeRegex = ShapeInputRegex();
            Regex numRegex = NumInputRegex();
            Regex shadingRegex = ShadingInputRegex();

            if (!colorRegex.IsMatch(cardInput))
            {
                return DisplayStrings.NO_VALID_COLOR_GIVEN;
            }
            else if (!shapeRegex.IsMatch(cardInput))
            {
                return DisplayStrings.NO_VALID_SHAPE_GIVEN;
            }
            else if (!numRegex.IsMatch(cardInput))
            {
                return DisplayStrings.NO_VALID_NUMBER_GIVEN;
            }
            else if (!shadingRegex.IsMatch(cardInput))
            {
                return DisplayStrings.NO_VALID_SHADING_GIVEN;
            }

            return "";
        }

        public Card GetCardFromInput(string cardInput)
        {
            if (cardInput.Length != 4)
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
    }

    public partial class InputService
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
