using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.DepthFrame
    //
    public sealed partial class DepthFrame : RootSystem.IDisposable, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal DepthFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_DepthFrame_AddRefObject(ref _pNative);
        }

        ~DepthFrame()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrame_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<DepthFrame>(_pNative);

            if (disposing)
            {
                Windows_Kinect_DepthFrame_Dispose(_pNative);
            }
                Windows_Kinect_DepthFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_DepthFrame_get_DepthFrameSource(RootSystem.IntPtr pNative);
        public  Windows.Kinect.DepthFrameSource DepthFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("DepthFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrame_get_DepthFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.DepthFrameSource>(objectPointer, n => new Windows.Kinect.DepthFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern ushort Windows_Kinect_DepthFrame_get_DepthMaxReliableDistance(RootSystem.IntPtr pNative);
        public  ushort DepthMaxReliableDistance
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("DepthFrame");
                }

                return Windows_Kinect_DepthFrame_get_DepthMaxReliableDistance(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern ushort Windows_Kinect_DepthFrame_get_DepthMinReliableDistance(RootSystem.IntPtr pNative);
        public  ushort DepthMinReliableDistance
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("DepthFrame");
                }

                return Windows_Kinect_DepthFrame_get_DepthMinReliableDistance(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_DepthFrame_get_FrameDescription(RootSystem.IntPtr pNative);
        public  Windows.Kinect.FrameDescription FrameDescription
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("DepthFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrame_get_FrameDescription(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.FrameDescription>(objectPointer, n => new Windows.Kinect.FrameDescription(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_DepthFrame_get_RelativeTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("DepthFrame");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_DepthFrame_get_RelativeTime(_pNative));
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative, RootSystem.IntPtr frameData, int frameDataSize);
        public void CopyFrameDataToArray(ushort[] frameData)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("DepthFrame");
            }

            var frameDataSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(frameData, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _frameData = frameDataSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_DepthFrame_CopyFrameDataToArray(_pNative, _frameData, frameData.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrame_Dispose(RootSystem.IntPtr pNative);
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
