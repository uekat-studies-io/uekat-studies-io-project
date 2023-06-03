using System.Text;

class Store : Point
{
    public Dictionary<ProductType, int> ProductNeeds { get; set; } = new();
    public int TotalNeed => ProductNeeds.Values.Sum();

    public override string ToString()
    {
        var output = new StringBuilder($"{Name} {{");
        foreach (var (productType, amount) in ProductNeeds)
        {
            output.Append($" {productType} = {amount} kg");
        }
        output.Append(" }");
        return output.ToString();
    }
}