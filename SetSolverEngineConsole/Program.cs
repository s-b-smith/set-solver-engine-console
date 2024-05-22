// See https://aka.ms/new-console-template for more information
using SetSolverEngineConsole.Models;
using SetSolverEngineConsole.Services;
using static SetSolverEngineConsole.Constants.CardProps;

Card[] cards = [
    new Card(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
    new Card(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
    new Card(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
    new Card(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
    new Card(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
    new Card(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID),
    new Card(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
    new Card(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
    new Card(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
    new Card(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
    new Card(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
    new Card(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
];

var solverService = new SolverService();
var solveResult = solverService.FindSets(cards);

Console.WriteLine(solveResult.ToString());
Console.WriteLine("ALL DONE!");