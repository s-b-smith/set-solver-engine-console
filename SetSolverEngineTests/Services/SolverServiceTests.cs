using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
using SetSolverEngineConsole.Services;

namespace SetSolverEngineTests.Services
{
    public class SolverServiceTests
    {
        private SolverService _solverService;

        [SetUp]
        public void Setup()
        {
            _solverService = new SolverService();
        }

        private static readonly object[] returnOneSetTestCases =
        [
            new Card[3] {
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.THREE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.THREE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.DIAMOND, CardProps.NUM.THREE, CardProps.SHADING.SHADED)
            },
            new Card[3] {
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.CIRCLE, CardProps.NUM.ONE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.ONE, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.ONE, CardProps.SHADING.SOLID)
            },
            new Card[3] {
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.ONE, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.TWO, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.RED, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.THREE, CardProps.SHADING.SOLID)
            },
        ];
        [TestCaseSource(nameof(returnOneSetTestCases))]
        public void FindSetsReturnsOneSet(Card[] cards)
        {
            var result = _solverService.FindSets(cards);

            Assert.That(result.numSets, Is.EqualTo(1));
        }
    }
}