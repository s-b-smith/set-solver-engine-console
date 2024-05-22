// See https://aka.ms/new-console-template for more information
using SetSolverEngineConsole.Models;
using SetSolverEngineConsole.Services;
using System.Reflection;

// TEST 1 (3 CARDS, 1 SET)
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.DIAMOND,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),

//// TEST 2 (3 CARDS, 1 SET)
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.PURPLE,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.DIAMOND,
//    SetSolverEngineConsole.Constants.CardProps.NUM.TWO,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SHADED
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.GREEN,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
//    SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SOLID
//),

//// TEST 3 (3 CARDS, 1 SET)
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.GREEN,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SOLID
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.PURPLE,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SHADED
//),

//// TEST 4 (3 CARDS, 0 SETS)
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.PURPLE,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.DIAMOND,
//    SetSolverEngineConsole.Constants.CardProps.NUM.TWO,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SHADED
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.GREEN,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
//    SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),

// TEST 5 (12 CARDS)
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.DIAMOND,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.TWO,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.PURPLE,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.DIAMOND,
//    SetSolverEngineConsole.Constants.CardProps.NUM.TWO,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SHADED
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.GREEN,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
//    SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SOLID
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.GREEN,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SOLID
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.PURPLE,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
//    SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SHADED
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
//    SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.PURPLE,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.DIAMOND,
//    SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.SHADED
//),
//new Card(
//    SetSolverEngineConsole.Constants.CardProps.COLOR.GREEN,
//    SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
//    SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
//    SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
//),

Card[] cards = [
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
        SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
        SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.DIAMOND,
        SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
        SetSolverEngineConsole.Constants.CardProps.NUM.TWO,
        SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.PURPLE,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.DIAMOND,
        SetSolverEngineConsole.Constants.CardProps.NUM.TWO,
        SetSolverEngineConsole.Constants.CardProps.SHADING.SHADED
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.GREEN,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
        SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.SOLID
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
        SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.GREEN,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
        SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.SOLID
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.PURPLE,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.OVAL,
        SetSolverEngineConsole.Constants.CardProps.NUM.ONE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.SHADED
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.RED,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
        SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.PURPLE,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.DIAMOND,
        SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.SHADED
    ),
    new Card(
        SetSolverEngineConsole.Constants.CardProps.COLOR.GREEN,
        SetSolverEngineConsole.Constants.CardProps.SHAPE.SQUIGGLE,
        SetSolverEngineConsole.Constants.CardProps.NUM.THREE,
        SetSolverEngineConsole.Constants.CardProps.SHADING.EMPTY
    ),
];

var solverService = new SolverService();
var solveResult = solverService.FindSets(cards);

Console.WriteLine(solveResult.ToString());
Console.WriteLine("ALL DONE!");