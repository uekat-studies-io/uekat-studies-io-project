class Store : Point
{
    public Dictionary<ProductType, int> ProductNeeds { get; set; } = new();
    public int TotalNeed => ProductNeeds.Values.Sum();
}