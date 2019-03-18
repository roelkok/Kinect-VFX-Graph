using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.ColorCameraSettings
    //
    public sealed partial class ColorCameraSettings : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal ColorCameraSettings(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_ColorCameraSettings_AddRefObject(ref _pNative);
        }

        ~ColorCameraSettings()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_ColorCameraSettings_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_ColorCameraSettings_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<ColorCameraSettings>(_pNative);
                Windows_Kinect_ColorCameraSettings_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_ColorCameraSettings_get_ExposureTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan ExposureTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("ColorCameraSettings");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_ColorCameraSettings_get_ExposureTime(_pNative));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_ColorCameraSettings_get_FrameInterval(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan FrameInterval
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("ColorCameraSettings");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_ColorCameraSettings_get_FrameInterval(_pNative));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern float Windows_Kinect_ColorCameraSettings_get_Gain(RootSystem.IntPtr pNative);
        public  float Gain
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("ColorCameraSettings");
                }

                return Windows_Kinect_ColorCameraSettings_get_Gain(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern float Windows_Kinect_ColorCameraSettings_get_Gamma(RootSystem.IntPtr pNative);
        public  float Gamma
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("ColorCameraSettings");
                }

                return Windows_Kinect_ColorCameraSettings_get_Gamma(_pNative);
            }
        }

        private void __EventCleanup()
        {
        }
    }

}
