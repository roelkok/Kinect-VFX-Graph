using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.MultiSourceFrameArrivedEventArgs
    //
    public sealed partial class MultiSourceFrameArrivedEventArgs : RootSystem.EventArgs, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal MultiSourceFrameArrivedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_MultiSourceFrameArrivedEventArgs_AddRefObject(ref _pNative);
        }

        ~MultiSourceFrameArrivedEventArgs()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_MultiSourceFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_MultiSourceFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<MultiSourceFrameArrivedEventArgs>(_pNative);
                Windows_Kinect_MultiSourceFrameArrivedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
        public  Windows.Kinect.MultiSourceFrameReference FrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("MultiSourceFrameArrivedEventArgs");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrameArrivedEventArgs_get_FrameReference(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.MultiSourceFrameReference>(objectPointer, n => new Windows.Kinect.MultiSourceFrameReference(n));
            }
        }

        private void __EventCleanup()
        {
        }
    }

}
