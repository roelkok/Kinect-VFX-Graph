using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.InfraredFrameReference
    //
    public sealed partial class InfraredFrameReference : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal InfraredFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_InfraredFrameReference_AddRefObject(ref _pNative);
        }

        ~InfraredFrameReference()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_InfraredFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_InfraredFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<InfraredFrameReference>(_pNative);
                Windows_Kinect_InfraredFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_InfraredFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("InfraredFrameReference");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_InfraredFrameReference_get_RelativeTime(_pNative));
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_InfraredFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
        public Windows.Kinect.InfraredFrame AcquireFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("InfraredFrameReference");
            }

            RootSystem.IntPtr objectPointer = Windows_Kinect_InfraredFrameReference_AcquireFrame(_pNative);
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.InfraredFrame>(objectPointer, n => new Windows.Kinect.InfraredFrame(n));
        }

        private void __EventCleanup()
        {
        }
    }

}
