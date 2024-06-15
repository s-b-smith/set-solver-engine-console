﻿using SetSolverEngineConsole.Models;
using SetSolverEngineConsole.Services;
using System.Text;
using static SetSolverEngineConsole.Constants.CardProps;

const string FINISHED = "F";

//Card[] cards = [
//    new Card(COLOR.RED, SHAPE.OVAL, NUM.ONE, SHADING.EMPTY),
//    new Card(COLOR.RED, SHAPE.SQUIGGLE, NUM.ONE, SHADING.EMPTY),
//    new Card(COLOR.RED, SHAPE.DIAMOND, NUM.ONE, SHADING.EMPTY),
//    new Card(COLOR.RED, SHAPE.OVAL, NUM.TWO, SHADING.EMPTY),
//    new Card(COLOR.PURPLE, SHAPE.DIAMOND, NUM.TWO, SHADING.SHADED),
//    new Card(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.SOLID),
//    new Card(COLOR.RED, SHAPE.OVAL, NUM.THREE, SHADING.EMPTY),
//    new Card(COLOR.GREEN, SHAPE.OVAL, NUM.ONE, SHADING.SOLID),
//    new Card(COLOR.PURPLE, SHAPE.OVAL, NUM.ONE, SHADING.SHADED),
//    new Card(COLOR.RED, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
//    new Card(COLOR.PURPLE, SHAPE.DIAMOND, NUM.THREE, SHADING.SHADED),
//    new Card(COLOR.GREEN, SHAPE.SQUIGGLE, NUM.THREE, SHADING.EMPTY),
//];

var solverService = new SolverService();
//var solveResult = solverService.FindSets(cards);

Console.WriteLine(getOpenTitle());

List<Card> cards = new();
do
{
    Console.WriteLine(getPrompt());
} while (Console.ReadLine() != FINISHED);

//Console.WriteLine(solveResult.ToString());
//Console.WriteLine("ALL DONE!");

string getOpenTitle()
{
    StringBuilder sb = new();

    sb.AppendLine("|||||||||||||||||||");
    sb.AppendLine("|||||||||||||||||||");
    sb.AppendLine("|||||-- SET --|||||");
    sb.AppendLine("||||-- SOLVER --|||");
    sb.AppendLine("|||||||||||||||||||");
    sb.AppendLine();
    sb.AppendLine("*******************");
    sb.AppendLine();
    sb.AppendLine("WELCOME!");
    sb.AppendLine();
    sb.AppendLine("Enter \"h\" for help");

    return sb.ToString();
}

string getPrompt()
{
    return $"Enter card(s), or \"{FINISHED}\" if finished:";
}