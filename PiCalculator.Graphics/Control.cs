using System.Drawing;
using SkiaSharp;

namespace PiCalculator.Graphics;

public abstract class Control
{
    public SKRect Bounds { get; init; } = new SKRect(0, 0, 32, 32);

    public bool Visible { get; set; } = true;

    public SKColor ForegroundColor { get; set; } = SKColors.Blue;

    public SKColor BackgroundColor { get; set; } = SKColors.Yellow;

    public SKColor TextColor { get; set; } = SKColors.Black;

    public float TextSize { get; set; } = 24;

    public event EventHandler OnTap;

    public event EventHandler OnLongTap; 

    public event EventHandler<Point> OnFingerDown;

    public event EventHandler<Point> OnFingerUp;

    protected Control()
    {
        
    }

    public void Initialize()
    {
        
    }

    public abstract void Invalidate(SKSurface surface);
}