class Point
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Distance(Point other) => Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
    public double MoveTo(Point other)
    {
        var moved = Distance(other);
        X = other.X;
        Y = other.Y;
        return moved;
    }
}