using System.Runtime.InteropServices;

namespace PiCalculator.Hardware.Native;

[StructLayout(LayoutKind.Sequential)]
struct pollfd
{
    public int fd;         /* file descriptor */
    public short events;     /* requested events */
    public short revents;    /* returned events */
}