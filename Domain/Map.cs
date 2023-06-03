class Map
{
    public List<Warehouse> Warehouses { get; set; } = new();
    public List<Car> Cars { get; set; } = new();
    public List<Store> Stores { get; set; } = new();

    public static Map Generate()
    {
        var map = new Map();
        var random = new Random();
        var (warehouseX, warehouseY) = ((double)random.Next(0, 101), (double)random.Next(0, 101));
        map.Warehouses.Append(new Warehouse
        {
            X = warehouseX,
            Y = warehouseY
        });
        var numberOfStores = random.Next(5, 11);
        for (var i = 0; i < numberOfStores; i++)
        {
            var (storeX, storeY) = ((double)random.Next(0, 101), (double)random.Next(0, 101));
            var need = random.Next(100, 201);
            map.Stores.Append(new Store
            {
                X = storeX,
                Y = storeY,
                ProductNeeds = new() { { ProductType.GenericProduct, need } }
            });
        }
        var numberOfCars = random.Next(3, 7);
        for (var i = 0; i < numberOfCars; i++)
        {
            map.Cars.Append(new Car
            {
                X = warehouseX,
                Y = warehouseY
            });
        }
        return map;
    }
}