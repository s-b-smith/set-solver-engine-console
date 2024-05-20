using SetSolverEngineConsole.Constants;
using SetSolverEngineConsole.Models;
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
                sb.Append($"{solveResult.numSets} total set{(solveResult.numSets > 1 ? "s" : "")}");
                sb.Append('\n');

                foreach (var set in solveResult.sets)
                {
                    sb.Append(set.ToString() + "\n\n");
                }

                return sb.ToString();
            }
        }

        private static IEnumerable<TestDataSet> TestCases()
        {
            // TEST 1: 3 CARDS, 1 SET (SHAPE DIFFERENT)
            yield return new TestDataSet([
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.THREE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.THREE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.DIAMOND, CardProps.NUM.THREE, CardProps.SHADING.SHADED)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.THREE, CardProps.SHADING.SHADED),
                        new(CardProps.COLOR.PURPLE, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.THREE, CardProps.SHADING.SHADED),
                        new(CardProps.COLOR.PURPLE, CardProps.SHAPE.DIAMOND, CardProps.NUM.THREE, CardProps.SHADING.SHADED)
                    )
                ]
               )
            );

            // TEST 2: 3 CARDS, 1 SET (SHAPE & SHADING DIFFERENT)
            yield return new TestDataSet([
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.CIRCLE, CardProps.NUM.ONE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.ONE, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.ONE, CardProps.SHADING.SOLID)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(CardProps.COLOR.GREEN, CardProps.SHAPE.CIRCLE, CardProps.NUM.ONE, CardProps.SHADING.SHADED),
                        new(CardProps.COLOR.GREEN, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.ONE, CardProps.SHADING.EMPTY),
                        new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.ONE, CardProps.SHADING.SOLID)
                    )
                ]
               )
            );

            // TEST 3: 3 CARDS, 1 SET (ALL DIFFERENT)
            yield return new TestDataSet([
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.ONE, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.TWO, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.RED, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.THREE, CardProps.SHADING.SOLID)
            ], new SetSolverResult(1,
                [
                    new Set(
                        new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.ONE, CardProps.SHADING.EMPTY),
                        new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.TWO, CardProps.SHADING.SHADED),
                        new(CardProps.COLOR.RED, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.THREE, CardProps.SHADING.SOLID)
                    )
                ]
               )
            );

            // TEST 4: 12 CARDS, 2 SETS
            yield return new TestDataSet([
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.TWO, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.ONE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.TWO, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.ONE, CardProps.SHADING.SOLID),
                new(CardProps.COLOR.RED, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.THREE, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.RED, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.ONE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.RED, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.THREE, CardProps.SHADING.SOLID),
                new(CardProps.COLOR.RED, CardProps.SHAPE.CIRCLE, CardProps.NUM.TWO, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.TWO, CardProps.SHADING.SOLID),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.THREE, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.TWO, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.CIRCLE, CardProps.NUM.THREE, CardProps.SHADING.SOLID)
            ], new SetSolverResult(2,
                [
                    new Set(
                        new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.ONE, CardProps.SHADING.SOLID),
                        new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.TWO, CardProps.SHADING.SHADED),
                        new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.THREE, CardProps.SHADING.EMPTY)
                    ),
                    new Set(
                        new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.TWO, CardProps.SHADING.SHADED),
                        new(CardProps.COLOR.RED, CardProps.SHAPE.CIRCLE, CardProps.NUM.TWO, CardProps.SHADING.EMPTY),
                        new(CardProps.COLOR.PURPLE, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.TWO, CardProps.SHADING.SOLID)
                    ),
                ]
               )
            );

            // TEST 5: 12 CARDS, 2 SETS
            yield return new TestDataSet([
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.ONE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.ONE, CardProps.SHADING.SOLID),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.THREE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.THREE, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.DIAMOND, CardProps.NUM.THREE, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.CIRCLE, CardProps.NUM.TWO, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.TWO, CardProps.SHADING.SOLID),
                new(CardProps.COLOR.PURPLE, CardProps.SHAPE.DIAMOND, CardProps.NUM.TWO, CardProps.SHADING.EMPTY),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.TWO, CardProps.SHADING.SOLID),
                new(CardProps.COLOR.RED, CardProps.SHAPE.DIAMOND, CardProps.NUM.THREE, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.RED, CardProps.SHAPE.DIAMOND, CardProps.NUM.TWO, CardProps.SHADING.SHADED),
                new(CardProps.COLOR.GREEN, CardProps.SHAPE.SQUIGGLE, CardProps.NUM.ONE, CardProps.SHADING.SOLID)
            ], new SetSolverResult(2,
                [
                    new Set(
                        new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.ONE, CardProps.SHADING.SHADED),
                        new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.TWO, CardProps.SHADING.SOLID),
                        new(CardProps.COLOR.PURPLE, CardProps.SHAPE.CIRCLE, CardProps.NUM.THREE, CardProps.SHADING.EMPTY)
                    ),
                    new Set(
                        new(CardProps.COLOR.PURPLE, CardProps.SHAPE.DIAMOND, CardProps.NUM.TWO, CardProps.SHADING.EMPTY),
                        new(CardProps.COLOR.GREEN, CardProps.SHAPE.DIAMOND, CardProps.NUM.TWO, CardProps.SHADING.SOLID),
                        new(CardProps.COLOR.RED, CardProps.SHAPE.DIAMOND, CardProps.NUM.TWO, CardProps.SHADING.SHADED)
                    ),
                ]
               )
            );
        }
    }
}
