using SkiaSharp;
class Visualiser
{
    Map map;

    public Visualiser(Map map)
    {
        this.map = map;
    }
    public void Visualize()
    {
        var surface = SKSurface.Create(new SKImageInfo
        {
            AlphaType = SKAlphaType.Opaque,
            ColorType = SKColorType.Rgba8888,
            Height = 1010,
            Width = 1010
        });
        var canvas = surface.Canvas;
        canvas.Clear(SKColors.White);
        var warehousePaint = new SKPaint()
        {
            Color = SKColors.Maroon
        };
        var storePaint = new SKPaint()
        {
            Color = SKColors.CornflowerBlue
        };
        foreach (var warehouse in map.Warehouses)
        {
            canvas.DrawRect(0 + (float)warehouse.X * 10, 0 + (float)warehouse.Y * 10, 10, 10, warehousePaint);
        }
        foreach (var store in map.Stores)
        {
            canvas.DrawRect(0 + (float)store.X * 10, 0 + (float)store.Y * 10, 10, 10, storePaint);
        }
        var image = surface.Snapshot();
        var data = image.Encode();
        data.SaveTo(new FileStream("output.png", FileMode.Create));
    }
}