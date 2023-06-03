// See https://aka.ms/new-console-template for more information
if (args.Count() < 1)
{
    Console.WriteLine("Error: no seed argument was provided.");
    return;
}
var seedOk = int.TryParse(args[0], out var seed);
if (!seedOk)
{
    Console.WriteLine("Error: invalid seed provided. The random seed must be a valid integer.");
    return;
}
var map = Map.Generate(seed);
var solution = Solver.Solve(map);
Console.WriteLine($"TOTAL SOLUTION: {solution} kilometers");