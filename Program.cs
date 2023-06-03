// See https://aka.ms/new-console-template for more information
var map = Map.Generate(404);
var solution = Solver.Solve(map);
Console.WriteLine($"TOTAL SOLUTION: {solution} kilometers");