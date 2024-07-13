using SetSolverEngineConsole.Models;
using System.Text;
using static SetSolverEngineConsole.Constants.CardProps;
using static SetSolverEngineTests.Services.SolverServiceTests;

namespace SetSolverEngineTests.Services
{
    public partial class InputServiceTests
    {
        private static IEnumerable<ValidateInputTestDataSet> ValidateCardInputTestCases()
        {
            // TEST 1: 3 CARDS, 1 SET (SHAPE DIFFERENT)
            //yield return new TestDataSet([
            //    new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.THREE, SHADING.STRIPED),
            //    new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.STRIPED),
            //    new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.STRIPED)
            //], new SetSolverResult(1,
            //    [
            //        new Set(
            //            new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.THREE, SHADING.STRIPED),
            //            new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.STRIPED),
            //            new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.STRIPED)
            //        )
            //    ]
            //   )
            //);
            throw new NotImplementedException();
        }

        private static IEnumerable<GetCardInputTestDataSet> GetCardInputTestCases()
        {
            throw new NotImplementedException();
        }

        public class ValidateInputTestDataSet(string cardInput, string result)
        {
            public readonly string cardInput = cardInput;
            public readonly string result = result;

            public override string ToString()
            {
                StringBuilder sb = new();
                sb.Append('\n');
                sb.Append(cardInput);
                sb.Append('\n');
                sb.Append(result);
                sb.Append('\n');

                return sb.ToString();
            }
        }

        public class GetCardInputTestDataSet(string cardInput, Card result)
        {
            public readonly string cardInput = cardInput;
            public readonly Card result = result;

            public override string ToString()
            {
                StringBuilder sb = new();
                sb.Append('\n');
                sb.Append(cardInput);
                sb.Append('\n');
                sb.Append(result.ToString());
                sb.Append('\n');

                return sb.ToString();
            }
        }
    }
}
