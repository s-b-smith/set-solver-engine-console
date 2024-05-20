using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
using static SetSolverEngineConsole.Constants.CardProps;
using SetSolverEngineConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.THREE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED)
                    )
                ]
               )
            );

            // TEST 2: 3 CARDS, 1 SET (SHAPE & SHADING DIFFERENT)
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.CIRCLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.GREEN, SHAPE.CIRCLE, NUM.ONE, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID)
                    )
                ]
               )
            );

            // TEST 3: 3 CARDS, 1 SET (ALL DIFFERENT)
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.TWO, SHADING.SHADED),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.TWO, SHADING.SHADED),
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
                new(COLOR.RED, SHAPE.CIRCLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.CIRCLE, NUM.THREE, SHADING.SOLID)
            ], new SetSolverResult(2,
                [
                    new Set(
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.CIRCLE, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID)
                    ),
                ]
               )
            );

            // TEST 5: 12 CARDS, 4 SETS
            yield return new TestDataSet([
                new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.ONE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.CIRCLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID)
            ], new SetSolverResult(4,
                [
                    new Set(
                        new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.ONE, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.TWO, SHADING.SOLID),
                        new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED)
                    ),
                    new Set(
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.ONE, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
                        new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SHADED)
                    ),
                ]
               )
            );

            // TEST 6: 12 CARDS, 2 SETS
            yield return new TestDataSet([
                new(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.CIRCLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.CIRCLE, NUM.ONE, SHADING.SHADED),
                new(COLOR.GREEN, SHAPE.CIRCLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.CIRCLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.DIAMOND, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY)
            ], new SetSolverResult(2,
                [
                    new Set(
                        new(COLOR.RED, SHAPE.CIRCLE, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.CIRCLE, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.ONE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.RED, SHAPE.CIRCLE, NUM.ONE, SHADING.SHADED),
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
                new(COLOR.GREEN, SHAPE.CIRCLE, NUM.THREE, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SOLID),
                new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.TWO, SHADING.EMPTY),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                new(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                new(COLOR.GREEN, SHAPE.CIRCLE, NUM.TWO, SHADING.SHADED),
                new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED)
            ], new SetSolverResult(3,
                [
                    new Set(
                        new(COLOR.RED, SHAPE.DIAMOND, NUM.THREE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
                        new(COLOR.GREEN, SHAPE.CIRCLE, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.CIRCLE, NUM.TWO, SHADING.EMPTY),
                        new(COLOR.PURPLE, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY)
                    ),
                    new Set(
                        new(COLOR.PURPLE, SHAPE.DIAMOND, NUM.ONE, SHADING.SHADED),
                        new(COLOR.RED, SHAPE.SQUIGGLE, NUM.TWO, SHADING.SOLID),
                        new(COLOR.GREEN, SHAPE.CIRCLE, NUM.THREE, SHADING.EMPTY)
                    ),
                ]
               )
            );

            // TODO: Need 3 more regular 12 card tests, 3 more no set 12 card tests, 2 15 card tests
            // Keep in mind edge cases: no cards of single prop (or two props?), 6,9,18 card tests (2 each)
        }
    }
}
