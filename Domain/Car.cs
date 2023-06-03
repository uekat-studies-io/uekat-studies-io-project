using System;
using System.Collections.Generic;
using System.Text;

class Car : Point
{
    public Dictionary<ProductType, int> Carrying { get; set; } = new() { { ProductType.GenericProduct, 0 } };
    public int Capacity { get; set; } = 1000;
    public int Total => Carrying.Values.Sum();
    public int CapacityLeft => Capacity - Total;

    public override string ToString()
    {
        var output = new StringBuilder("Car carrying {");
        foreach (var pair in Carrying)
        {
            output.Append($" {pair.Key} = {pair.Value} ");
        }
        output.Append("}");
        return output.ToString();
    }
}