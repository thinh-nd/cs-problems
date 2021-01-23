using System;
using CsProblems;

var values = new[] { 10, 100, 40 };
var weights = new[] { 10, 40, 20 };
var maxWeight = 58;

var result = FractionalKnapsack.FillSack(values, weights, maxWeight);
Console.WriteLine(string.Join(',', result));
Console.ReadLine();
