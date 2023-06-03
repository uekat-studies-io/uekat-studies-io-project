using System;
using System.Collections.Generic;
class Car : Point
{
    public Dictionary<ProductType, int> Carrying { get; set; } = new() { { ProductType.GenericProduct, 0 } };
    public int Capacity { get; set; } = 1000;
}