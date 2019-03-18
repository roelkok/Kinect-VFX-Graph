using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.KinectUnityAddinUtils
    //
    public sealed partial class KinectUnityAddinUtils
    {
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void KinectUnityAddin_FreeMemory(RootSystem.IntPtr pToDealloc);
        public static void FreeMemory(RootSystem.IntPtr pToDealloc)
        {
            KinectUnityAddin_FreeMemory(pToDealloc);
        }
    }

}
