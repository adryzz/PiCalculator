using System;
using System.Runtime.InteropServices;
using __u16 = System.UInt16;
using __u32 = System.UInt32;

namespace PiCalculator.Hardware.Native;

[StructLayout(LayoutKind.Sequential)]
unsafe struct fb_fix_screeninfo
{
    public fixed byte id[16];	/* identification string eg "TT Builtin" */

    public IntPtr smem_start;	/* Start of frame buffer mem */

    /* (physical address) */
    public __u32 smem_len;		/* Length of frame buffer mem */

    public __u32 type;			/* see FB_TYPE_*		*/
    public __u32 type_aux;		/* Interleave for interleaved Planes */
    public __u32 visual;		/* see FB_VISUAL_*		*/
    public __u16 xpanstep;		/* zero if no hardware panning  */
    public __u16 ypanstep;		/* zero if no hardware panning  */
    public __u16 ywrapstep;		/* zero if no hardware ywrap    */
    public __u32 line_length;	/* length of a line in bytes    */

    public IntPtr mmio_start;	/* Start of Memory Mapped I/O   */

    /* (physical address) */
    public __u32 mmio_len;		/* Length of Memory Mapped I/O  */

    public __u32 accel;			/* Type of acceleration available */
    public fixed __u16 reserved[3]; /* Reserved for future compatibility */
}