using SetSolverEngineConsole.Models;
using System.Text;
using static SetSolverEngineConsole.Constants.CardProps;

namespace SetSolverEngineTests.Services
{
    public partial class SolverServiceTests
    {
        public class TestDataSet(Card[] cards, SetSolverResult solveResult)
        {
            public readonly Card[] cards = cards;
            public readonly SetSolverResult solveResult = solveResult;

            public override string ToString()
            {
                StringBuilder sb = new();
                sb.Append('\n');
                foreach (var card in cards)
                {
                    sb.Append(card.ToString() + '\n');
                }

                sb.Append('\n');
                sb.Append(solveResult.ToString());
                sb.Append('\n');

                return sb.ToString();
            }
        }

        private static IEnumerable<TestDataSet> TestCases()
        {
            // TEST 1: 3 CARDS, 1 SET (SHAPE DIFFERENT)
            yield return new TestDataSet([
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED)
                    )
                ]
               )
            );

            // TEST 2: 3 CARDS, 1 SET (SHAPE & SHADING DIFFERENT)
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID)
                    )
                ]
               )
            );

            // TEST 3: 3 CARDS, 1 SET (ALL DIFFERENT)
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID)
                    )
                ]
               )
            );

            // TEST 4: 12 CARDS, 2 SETS
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SOLID)
            ], new SetSolverResult(2,
                [
                    new Set(
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID)
                    ),
                ]
               )
            );

            // TEST 5: 12 CARDS, 4 SETS
            yield return new TestDataSet([
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID)
            ], new SetSolverResult(4,
                [
                    new Set(
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED)
                    ),
                ]
               )
            );

            // TEST 6: 12 CARDS, 2 SETS
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY)
            ], new SetSolverResult(2,
                [
                    new Set(
                        new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID)
                    ),
                ]
               )
            );

            // TEST 7: 12 CARDS, 3 SETS
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED)
            ], new SetSolverResult(3,
                [
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY)
                    ),
                ]
               )
            );

            // TEST 8: 12 CARDS, 1 SET
            yield return new TestDataSet([
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SHADED)
                    ),
                ]
               )
            );

            // TEST 9: 12 CARDS, 1 SET
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SHADED)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID)
                    ),
                ]
               )
            );

            // TEST 10: 12 CARDS, 0 SETS
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.SOLID)
            ], new SetSolverResult(0, [])
            );

            // TEST 11: 12 CARDS, 0 SETS
            yield return new TestDataSet([
                new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY)
            ], new SetSolverResult(0, [])
            );

            // TEST 12: 12 CARDS, 0 SETS
            yield return new TestDataSet([
                new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID)
            ], new SetSolverResult(0, [])
            );

            // TEST 13: 15 CARDS, 8 SETS
            yield return new TestDataSet([
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SHADED)
            ], new SetSolverResult(8,
                [
                    new Set(
                        new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.SHADED)
                    ),
                ]
               )
            );

            // TEST 14: 15 CARDS, 3 SETS
            yield return new TestDataSet([
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SHADED)
            ], new SetSolverResult(4,
                [
                    new Set(
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SOLID)
                    ),
                    new Set(
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SHADED)
                    ),
                ]
               )
            );

            // TEST 15: 12 CARDS, 3 SETS (NO "ONE" CARDS)
            yield return new TestDataSet([
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY)
            ], new SetSolverResult(3, 
                [
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID)
                    ),
                ]
               )
            );

            // TEST 16: 12 CARDS, 2 SETS (NO "SHADED" CARDS)
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID)
            ], new SetSolverResult(2,
                [
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.SOLID)
                    ),
                ]
               )
            );

            // TEST 17: 12 CARDS, 1 SET (NO "PURPLE" OR "TWO" CARDS)
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID)
                    ),
                ]
               )
            );

            // TEST 18: 12 CARDS, 2 SETS (NO "SQUIGGLE" OR "SHADED" CARDS)
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SOLID)
            ], new SetSolverResult(2,
                [
                    new Set(
                        new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.THREE, SHADING.SOLID)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.SOLID)
                    ),
                ]
               )
            );

            // TEST 19: 6 CARDS, 1 SET
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SOLID)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED)
                    ),
                ]
               )
            );

            // TEST 20: 9 CARDS, 0 SETS
            yield return new TestDataSet([
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY)
            ], new SetSolverResult(0,[])
            );

            // TEST 21: 18 CARDS, 13 SETS
            yield return new TestDataSet([
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID)
            ], new SetSolverResult(13,
                [
                    new Set(
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.OVAL, NUM.TWO, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID)
                    ),
                    new Set(
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED)
                    ),
                ]
               )
            );
        }
    }
}
