using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.ColorFrame
    //
    public sealed partial class ColorFrame : RootSystem.IDisposable, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal ColorFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_ColorFrame_AddRefObject(ref _pNative);
        }

        ~ColorFrame()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_ColorFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_ColorFrame_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<ColorFrame>(_pNative);

            if (disposing)
            {
                Windows_Kinect_ColorFrame_Dispose(_pNative);
            }
                Windows_Kinect_ColorFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_get_ColorCameraSettings(RootSystem.IntPtr pNative);
        public  Windows.Kinect.ColorCameraSettings ColorCameraSettings
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("ColorFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrame_get_ColorCameraSettings(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.ColorCameraSettings>(objectPointer, n => new Windows.Kinect.ColorCameraSettings(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_get_ColorFrameSource(RootSystem.IntPtr pNative);
        public  Windows.Kinect.ColorFrameSource ColorFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("ColorFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrame_get_ColorFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.ColorFrameSource>(objectPointer, n => new Windows.Kinect.ColorFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_get_FrameDescription(RootSystem.IntPtr pNative);
        public  Windows.Kinect.FrameDescription FrameDescription
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("ColorFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrame_get_FrameDescription(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.FrameDescription>(objectPointer, n => new Windows.Kinect.FrameDescription(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.Kinect.ColorImageFormat Windows_Kinect_ColorFrame_get_RawColorImageFormat(RootSystem.IntPtr pNative);
        public  Windows.Kinect.ColorImageFormat RawColorImageFormat
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("ColorFrame");
                }

                return Windows_Kinect_ColorFrame_get_RawColorImageFormat(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_ColorFrame_get_RelativeTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("ColorFrame");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_ColorFrame_get_RelativeTime(_pNative));
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_ColorFrame_CopyRawFrameDataToArray(RootSystem.IntPtr pNative, RootSystem.IntPtr frameData, int frameDataSize);
        public void CopyRawFrameDataToArray(byte[] frameData)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("ColorFrame");
            }

            var frameDataSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(frameData, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _frameData = frameDataSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_ColorFrame_CopyRawFrameDataToArray(_pNative, _frameData, frameData.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_ColorFrame_CopyConvertedFrameDataToArray(RootSystem.IntPtr pNative, RootSystem.IntPtr frameData, int frameDataSize, Windows.Kinect.ColorImageFormat colorFormat);
        public void CopyConvertedFrameDataToArray(byte[] frameData, Windows.Kinect.ColorImageFormat colorFormat)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("ColorFrame");
            }

            var frameDataSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(frameData, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _frameData = frameDataSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_ColorFrame_CopyConvertedFrameDataToArray(_pNative, _frameData, frameData.Length, colorFormat);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_ColorFrame_CreateFrameDescription(RootSystem.IntPtr pNative, Windows.Kinect.ColorImageFormat format);
        public Windows.Kinect.FrameDescription CreateFrameDescription(Windows.Kinect.ColorImageFormat format)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("ColorFrame");
            }

            RootSystem.IntPtr objectPointer = Windows_Kinect_ColorFrame_CreateFrameDescription(_pNative, format);
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.FrameDescription>(objectPointer, n => new Windows.Kinect.FrameDescription(n));
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_ColorFrame_Dispose(RootSystem.IntPtr pNative);
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
