using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.BodyFrame
    //
    public sealed partial class BodyFrame : RootSystem.IDisposable, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal BodyFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_BodyFrame_AddRefObject(ref _pNative);
        }

        ~BodyFrame()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyFrame_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<BodyFrame>(_pNative);

            if (disposing)
            {
                Windows_Kinect_BodyFrame_Dispose(_pNative);
            }
                Windows_Kinect_BodyFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_BodyFrame_get_BodyCount(RootSystem.IntPtr pNative);
        public  int BodyCount
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyFrame");
                }

                return Windows_Kinect_BodyFrame_get_BodyCount(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyFrame_get_BodyFrameSource(RootSystem.IntPtr pNative);
        public  Windows.Kinect.BodyFrameSource BodyFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrame_get_BodyFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.BodyFrameSource>(objectPointer, n => new Windows.Kinect.BodyFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyFrame_get_FloorClipPlane(RootSystem.IntPtr pNative);
        public  Windows.Kinect.Vector4 FloorClipPlane
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyFrame");
                }

                var objectPointer = Windows_Kinect_BodyFrame_get_FloorClipPlane(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                var obj = (Windows.Kinect.Vector4)RootSystem.Runtime.InteropServices.Marshal.PtrToStructure(objectPointer, typeof(Windows.Kinect.Vector4));
                Windows.Kinect.KinectUnityAddinUtils.FreeMemory(objectPointer);
                return obj;
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_BodyFrame_get_RelativeTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyFrame");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_BodyFrame_get_RelativeTime(_pNative));
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyFrame_Dispose(RootSystem.IntPtr pNative);
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
