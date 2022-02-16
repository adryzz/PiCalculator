using PiCalculator.Graphics.Controls;
using PiCalculator.Hardware;
using SkiaSharp;

namespace PiCalculator;

public static class Program
{
    private static Button _button;
    public static void Main(string[] args)
    {
        FrameBuffer buffer = new FrameBuffer();
        _button = new Button
        {
            Bounds = new SKRect(50, 50, 200, 100),
            Text = "Click Me"
        };
        
        _button.Initialize();
        buffer.OnDraw += Paint;
        while (true)
        {
            //Thread.Sleep(10);
            buffer.Invalidate();
        }
    }

    public static void Paint(object? sender, SKSurface paintSurface)
    {
        _button.Invalidate(paintSurface);
    }
}