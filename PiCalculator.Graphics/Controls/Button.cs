using SkiaSharp;

namespace PiCalculator.Graphics.Controls;

public class Button : Control
{
    public string Text { get; set; } = String.Empty;

    public override void Invalidate(SKSurface surface)
    {
        if (Visible)
        {
            var foregroundBrush = new SKPaint {
                Color = ForegroundColor,
                IsStroke = true
            };
            surface.Canvas.DrawRect(Bounds, foregroundBrush);
        
            var backgroundBrush = new SKPaint {
                Color = BackgroundColor,
                IsStroke = false
            };

            surface.Canvas.DrawRect(Bounds, backgroundBrush);
        
            var textBrush = new SKPaint {
                Color = TextColor,
                IsStroke = false,
                TextSize = TextSize,
                IsAntialias = true
            };
            
            SKRect textBounds = new SKRect(); textBrush.MeasureText(Text, ref textBounds);
            
            surface.Canvas.DrawText(Text, Bounds.MidX - textBounds.MidX, Bounds.MidY - textBounds.MidY, textBrush);
        }
        else
        {
            surface.Canvas.Clear();
        }
    }
}