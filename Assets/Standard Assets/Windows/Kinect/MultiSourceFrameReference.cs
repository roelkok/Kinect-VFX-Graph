using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.MultiSourceFrameReference
    //
    public sealed partial class MultiSourceFrameReference : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal MultiSourceFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_MultiSourceFrameReference_AddRefObject(ref _pNative);
        }

        ~MultiSourceFrameReference()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_MultiSourceFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_MultiSourceFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<MultiSourceFrameReference>(_pNative);
                Windows_Kinect_MultiSourceFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_MultiSourceFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
        public Windows.Kinect.MultiSourceFrame AcquireFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("MultiSourceFrameReference");
            }

            RootSystem.IntPtr objectPointer = Windows_Kinect_MultiSourceFrameReference_AcquireFrame(_pNative);
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.MultiSourceFrame>(objectPointer, n => new Windows.Kinect.MultiSourceFrame(n));
        }

        private void __EventCleanup()
        {
        }
    }

}
