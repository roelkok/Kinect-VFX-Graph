using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.LongExposureInfraredFrame
    //
    public sealed partial class LongExposureInfraredFrame : RootSystem.IDisposable, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal LongExposureInfraredFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_LongExposureInfraredFrame_AddRefObject(ref _pNative);
        }

        ~LongExposureInfraredFrame()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_LongExposureInfraredFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_LongExposureInfraredFrame_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<LongExposureInfraredFrame>(_pNative);

            if (disposing)
            {
                Windows_Kinect_LongExposureInfraredFrame_Dispose(_pNative);
            }
                Windows_Kinect_LongExposureInfraredFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrame_get_FrameDescription(RootSystem.IntPtr pNative);
        public  Windows.Kinect.FrameDescription FrameDescription
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrame_get_FrameDescription(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.FrameDescription>(objectPointer, n => new Windows.Kinect.FrameDescription(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_LongExposureInfraredFrame_get_LongExposureInfraredFrameSource(RootSystem.IntPtr pNative);
        public  Windows.Kinect.LongExposureInfraredFrameSource LongExposureInfraredFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_LongExposureInfraredFrame_get_LongExposureInfraredFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.LongExposureInfraredFrameSource>(objectPointer, n => new Windows.Kinect.LongExposureInfraredFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_LongExposureInfraredFrame_get_RelativeTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_LongExposureInfraredFrame_get_RelativeTime(_pNative));
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_LongExposureInfraredFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative, RootSystem.IntPtr frameData, int frameDataSize);
        public void CopyFrameDataToArray(ushort[] frameData)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("LongExposureInfraredFrame");
            }

            var frameDataSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(frameData, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _frameData = frameDataSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_LongExposureInfraredFrame_CopyFrameDataToArray(_pNative, _frameData, frameData.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_LongExposureInfraredFrame_Dispose(RootSystem.IntPtr pNative);
        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        private void __EventCleanup()
        {
        }
    }

}
