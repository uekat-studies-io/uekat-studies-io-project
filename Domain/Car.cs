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
        var output = new StringBuilder("Car carrying {");
        foreach (var pair in Cargo)
        {
            output.Append($" {pair.Key} = {pair.Value} ");
        }
        output.Append("}");
        return output.ToString();
    }
    public double MoveTo(Point other)
    {
        var moved = Distance(other);
        Console.WriteLine($"{Name} moving {moved:0.00}km to ${other.Name}");
        X = other.X;
        Y = other.Y;
        return moved;
    }
}
enum CarClass
{
    Green = 1000,
    Blue = 1500,
    Red = 2000
}