using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.LongExposureInfraredFrameReference
    //
    public sealed partial class LongExposureInfraredFrameReference : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal LongExposureInfraredFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_LongExposureInfraredFrameReference_AddRefObject(ref _pNative);
        }

        ~LongExposureInfraredFrameReference()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_LongExposureInfraredFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_LongExposureInfraredFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<LongExposureInfraredFrameReference>(_pNative);
                Windows_Kinect_LongExposureInfraredFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_LongExposureInfraredFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReference");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_LongExposureInfraredFrameReference_get_RelativeTime(_pNative));
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrameReference_AcquireFrame(RootSystem.IntPtr pNative);
        public Windows.Kinect.LongExposureInfraredFrame AcquireFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrameReference");
            }

            RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrameReference_AcquireFrame(_pNative);
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.LongExposureInfraredFrame>(objectPointer, n => new Windows.Kinect.LongExposureInfraredFrame(n));
        }

        private void __EventCleanup()
        {
        }
    }

}
