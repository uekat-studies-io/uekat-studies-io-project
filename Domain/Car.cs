using System;
using System.Collections.Generic;
using System.Text;

class Car : Point
{
    public Dictionary<ProductType, int> Cargo { get; set; } = new() { { ProductType.GenericProduct, 0 } };
    public int Capacity { get; set; } = 1000;
    public int Total => Cargo.Values.Sum();
    public int CapacityLeft => Capacity - Total;

    public override string ToString()
    {
        var output = new StringBuilder($"{Name} carrying {{");
        foreach (var pair in Cargo)
        {
            output.Append($" {pair.Key} = {pair.Value} kg");
        }
        output.Append(" }, ");
        output.Append($"capacity: {Total} / {Capacity} kg");
        return output.ToString();
    }
    public double MoveTo(Point other)
    {
        var moved = Distance(other);
        Console.WriteLine($"{Name} moving {moved:0.00} km to {other.Name}");
        X = other.X;
        Y = other.Y;
        return moved;
    }

    public void Load(Dictionary<ProductType, int> needs, Warehouse source)
    {
        Console.WriteLine($"{Name} loading up at {source.Name}");
        foreach (var (productType, need) in needs.OrderByDescending(pair => pair.Value))
        {
            Cargo[productType] += Math.Min(CapacityLeft, need);
            Console.WriteLine($"{Name} loads {Math.Min(CapacityLeft, need)} of {productType}");
        }
        Console.WriteLine($"Car status after loading: {this}");
    }
    public void Serve(Store store)
    {
        Console.WriteLine($"Store awaits delivery: {store}");
        foreach (var (productType, amount) in Cargo)
        {
            var amountNeeded = store.ProductNeeds[productType];
            store.ProductNeeds[productType] -= Math.Min(amount, amountNeeded);
            Cargo[productType] -= Math.Min(amount, amountNeeded);
            Console.WriteLine($"{Name} unloading {Math.Min(amount, amountNeeded)} kg of {productType} at {store.Name}");
        }
        Console.WriteLine($"Store status after delivery: {store}");
        Console.WriteLine($"Car status: {this}");
    }
}
enum CarClass
{
    Green = 1000,
    Blue = 1500,
    Red = 2000
}