using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace Helper
{
    internal interface INativeWrapper
    {
        System.IntPtr nativePtr { get; }
    }
}