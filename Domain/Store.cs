using System.Text;

class Store : Point
{
    public bool IsUnloading = false;
    public Dictionary<ProductType, int> ProductNeeds { get; set; } = new();
    public int TotalNeed => ProductNeeds.Values.Sum();

    public override string ToString()
    {
        var output = new StringBuilder($"{Name} {{");
        if (IsUnloading) output.Append(" Wants to hand off:");
        foreach (var (productType, amount) in ProductNeeds)
        {
            output.Append($" {productType} = {amount} kg");
        }
        output.Append(" }");
        return output.ToString();
    }
}