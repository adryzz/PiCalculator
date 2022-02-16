using System;
using System.Drawing;
using PiCalculator.Hardware.Native;
using SkiaSharp;

namespace PiCalculator.Hardware;

public class FrameBuffer
{
    private FrameBufferDevice _fbDev;
    private SKBitmap? bitmap;
    private int renderCount = 0;

    public event EventHandler<SKSurface> OnDraw;
    
    public FrameBuffer()
    {
        _fbDev = new FrameBufferDevice();
        _fbDev.Init();

        var resolution = _fbDev.ScreenSize;
    }

    public Size PixelSize => _fbDev.ScreenSize;

    public void Invalidate()
    {
        int width, height;

        var dpi = 1;

        var resolution = _fbDev.ScreenSize;

        width = (int)resolution.Width;
        height = (int)resolution.Height;

        var scaledWidth = (int)(width * dpi);
        var scaledHeight = (int)(height * dpi);

        var info = new SKImageInfo(scaledWidth, scaledHeight, SKImageInfo.PlatformColorType, SKAlphaType.Premul);

        // reset the bitmap if the size has changed
        if (bitmap == null || info.Width != bitmap.Width || info.Height != bitmap.Height)
        {
            bitmap = new SKBitmap(scaledWidth, scaledHeight, _fbDev.PixelFormat, SKAlphaType.Premul);
        }

        using (var surface = SKSurface.Create(info, bitmap.GetPixels(out _)))
        {
            surface.Canvas.Clear(SKColors.White);

            surface.Canvas.Scale((float)dpi);

            //render
            OnDraw?.Invoke(this, surface);

            _fbDev.VSync();
            LibC.memcpy(_fbDev.BufferAddress, bitmap.GetPixels(out _), new IntPtr(_fbDev.RowBytes * height));
        }
    }
}