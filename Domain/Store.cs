class Store : Point
{
    public Dictionary<ProductType, int> Need { get; set; } = new();
}