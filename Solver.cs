static class Solver
{
    static bool WinCondition(Map map) => map.Stores.All(store => store.ProductNeeds.Values.All(need => need == 0));
    public static double Solve(Map map)
    {
        double totalDistance = 0;
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
                car.Cargo[pair.Key] += toFill;
                totalGoodAmount -= toFill;
            }
        }
        Console.WriteLine("Cars after filling up:");
        map.Cars.ForEach(Console.WriteLine);
        while (!WinCondition(map))
        {
            // For every unsatisfied store, starting with those with the biggest needs:
            var unsatisfiedStores = map.Stores.Where(store => store.TotalNeed != 0)
            .OrderByDescending(store => store.TotalNeed);
            foreach (var store in unsatisfiedStores)
            {
                // Find the most satisfying car:
                var car = MostSatisfyingCar(map, store);
                // If no car was found above a satisfaction score of 0.5, find the car nearest to the nearest warehouse, then fill it up
                if (car == null)
                {
                    var warehouse = map.Warehouses.OrderBy(warehouse => warehouse.Distance(store)).First();
                    car = map.Cars.OrderBy(car => car.Distance(warehouse)).First();
                    totalDistance += car.MoveTo(warehouse);
                    // fill up greedily
                    foreach (var (productType, need) in store.ProductNeeds.OrderByDescending(pair => pair.Value))
                    {
                        car.Cargo[productType] += Math.Min(car.CapacityLeft, need);
                    }
                }
                // Send the car to the store.
                totalDistance += car.MoveTo(store);
                // Unload.
                foreach (var (productType, amount) in car.Cargo)
                {
                    var amountNeeded = store.ProductNeeds[productType];
                    store.ProductNeeds[productType] -= Math.Min(amount, amountNeeded);
                    car.Cargo[productType] -= Math.Min(amount, amountNeeded);
                }

                break; // we want to recalculate after every delivery run
            }
        }
        return totalDistance;
    }
    public static Car? MostSatisfyingCar(Map map, Store store, double satisfactionThreshold = 0.5)
    {
        var carsBySatisfaction = map.Cars.Select(car => new
        {
            Car = car,
            Score = SatisfactionScore(car, store)
        }).OrderByDescending(pair => pair.Score);
        return carsBySatisfaction.FirstOrDefault(x => x.Score > satisfactionThreshold)?.Car;
    }
    public static double SatisfactionScore(Car car, Store store)
    {
        // Satisfaction score: percentage of store's need satisfied by the car's cargo divided by the distance between them.
        var maxPossibleDistance = Math.Sqrt(Math.Pow(Map.MAX_MAP_X, 2) + Math.Pow(Map.MAX_MAP_Y, 2));
        var distanceScore = (store.Distance(car) / maxPossibleDistance) * 2; // a perfectly satisfying car on the other end of the map should have a satisfaction score of 0.5
        var totalDemanded = store.TotalNeed;
        var totalCarried = 0;
        foreach (var (productType, amount) in car.Cargo)
        {
            if (store.ProductNeeds.ContainsKey(productType)) totalCarried += amount;
        }
        var supplyScore = (double)totalCarried / (double)totalDemanded; // 1.0 if a car has everything a store needs
        return supplyScore / distanceScore;
    }
}