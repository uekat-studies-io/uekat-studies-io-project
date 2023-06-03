class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public string Name { get; set; } = "";
    public double Distance(Point other) => Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
}