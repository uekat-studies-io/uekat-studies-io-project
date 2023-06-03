class Map
{
    public const int MAX_MAP_X = 100;
    public const int MAX_MAP_Y = 100;
    public List<Warehouse> Warehouses = new();
    public List<Car> Cars = new();
    public List<Store> Stores = new();

    public static Map Generate(int seed)
    {
        Console.WriteLine($"Generating map with seed {seed}...");
        var map = new Map();
        var random = new Random(seed);
        for (var i = 0; i < 5; i++)
        {
            var (warehouseX, warehouseY) = ((double)random.Next(0, MAX_MAP_X + 1), (double)random.Next(0, MAX_MAP_Y + 1));
            map.Warehouses.Add(new Warehouse
            {
                X = warehouseX,
                Y = warehouseY,
                Name = $"Warehouse #{i + 1}"
            });
            map.Warehouses.ForEach(warehouse =>
            {
                Console.WriteLine($"{warehouse.Name}: ({warehouse.X}, {warehouse.Y})");
            });
        }
        var numberOfStores = random.Next(5, 21);
        for (var i = 0; i < numberOfStores; i++)
        {
            var (storeX, storeY) = ((double)random.Next(0, MAX_MAP_X + 1), (double)random.Next(0, MAX_MAP_Y + 1));
            var need = random.Next(100, 201);
            map.Stores.Add(new Store
            {
                IsUnloading = (random.Next() % 2 == 0),
                X = storeX,
                Y = storeY,
                ProductNeeds = new() { { ProductType.GenericProduct, need } },
                Name = $"Store #{i + 1}"
            });
            map.Stores.ForEach(store =>
            {
                Console.WriteLine($"{store.Name}: ({store.X}, {store.Y})");
            });
        }
        var numberOfCars = random.Next(3, 7);
        for (var i = 0; i < numberOfCars; i++)
        {
            var carClass = random.Next(0, 2) switch
            {
                0 => CarClass.Blue,
                1 => CarClass.Green,
                2 => CarClass.Red,
                _ => throw new Exception("Value out of range for car classes")
            };
            var warehouse = map.Warehouses[random.Next(0, map.Warehouses.Count)];
            var car = new Car
            {
                X = warehouse.X,
                Y = warehouse.Y,
                Name = $"{carClass} Car #{i + 1}",
                Capacity = (int)carClass
            };
            map.Cars.Add(car);
            Console.WriteLine($"{car.Name} spawned at {warehouse.Name}");
        }
        return map;
    }
}