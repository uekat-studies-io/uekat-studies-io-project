static class Solver
{
    static bool WinCondition(Map map) => map.Stores.All(store => store.ProductNeeds.Values.All(need => need == 0));
    public static double Solve(Map map)
    {
        var totalDistance = 0;
        // How much do we need of everything?
        var totalNeeds = new Dictionary<ProductType, int>() {
            {ProductType.GenericProduct, 0}
        };
        foreach (var pair in map.Stores.SelectMany(store => store.ProductNeeds))
        {
            totalNeeds[pair.Key] += pair.Value;
        }
        // Let's try to fill up our cars with that much. We will do so greedily, ie. starting with the most-needed goods first.
        Console.WriteLine("Total needs:");
        foreach (var pair in totalNeeds.OrderByDescending(x => x.Value))
        {
            Console.WriteLine($"Need for {pair.Key} = {pair.Value}");
            var totalGoodAmount = pair.Value;
            foreach (var car in map.Cars.Where(car => car.CapacityLeft > 0))
            {
                var toFill = Math.Min(car.CapacityLeft, totalGoodAmount);
                car.Carrying[pair.Key] += toFill;
                totalGoodAmount -= toFill;
            }
        }
        Console.WriteLine("Cars after filling up:");
        map.Cars.ForEach(Console.WriteLine);
        while (!WinCondition(map))
        {
            // For every unsatisfied store:
            foreach (var stores in map.Stores.Where(store => store.ProductNeeds.Values.Any(need => need != 0)))
            {
                // Find nearest car with the needed goods:

            }
            break;
        }
        return totalDistance;
    }
}