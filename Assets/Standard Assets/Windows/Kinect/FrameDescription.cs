using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.FrameDescription
    //
    public sealed partial class FrameDescription : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal FrameDescription(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_FrameDescription_AddRefObject(ref _pNative);
        }

        ~FrameDescription()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_FrameDescription_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_FrameDescription_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<FrameDescription>(_pNative);
                Windows_Kinect_FrameDescription_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern uint Windows_Kinect_FrameDescription_get_BytesPerPixel(RootSystem.IntPtr pNative);
        public  uint BytesPerPixel
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameDescription");
                }

                return Windows_Kinect_FrameDescription_get_BytesPerPixel(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern float Windows_Kinect_FrameDescription_get_DiagonalFieldOfView(RootSystem.IntPtr pNative);
        public  float DiagonalFieldOfView
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameDescription");
                }

                return Windows_Kinect_FrameDescription_get_DiagonalFieldOfView(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_FrameDescription_get_Height(RootSystem.IntPtr pNative);
        public  int Height
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameDescription");
                }

                return Windows_Kinect_FrameDescription_get_Height(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern float Windows_Kinect_FrameDescription_get_HorizontalFieldOfView(RootSystem.IntPtr pNative);
        public  float HorizontalFieldOfView
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameDescription");
                }

                return Windows_Kinect_FrameDescription_get_HorizontalFieldOfView(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern uint Windows_Kinect_FrameDescription_get_LengthInPixels(RootSystem.IntPtr pNative);
        public  uint LengthInPixels
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameDescription");
                }

                return Windows_Kinect_FrameDescription_get_LengthInPixels(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern float Windows_Kinect_FrameDescription_get_VerticalFieldOfView(RootSystem.IntPtr pNative);
        public  float VerticalFieldOfView
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameDescription");
                }

                return Windows_Kinect_FrameDescription_get_VerticalFieldOfView(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_FrameDescription_get_Width(RootSystem.IntPtr pNative);
        public  int Width
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("FrameDescription");
                }

                return Windows_Kinect_FrameDescription_get_Width(_pNative);
            }
        }

        private void __EventCleanup()
        {
        }
    }

}
