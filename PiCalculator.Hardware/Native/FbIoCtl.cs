namespace PiCalculator.Hardware.Native;

enum FbIoCtl : uint
{
    FBIOGET_VSCREENINFO = 0x4600,
    FBIOPUT_VSCREENINFO = 0x4601,
    FBIOGET_FSCREENINFO = 0x4602,
    FBIO_WAITFORVSYNC = 0x40044620,
}