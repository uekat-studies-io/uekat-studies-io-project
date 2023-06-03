class Store : Point
{
    public Dictionary<ProductType, int> ProductNeeds { get; set; } = new();
}