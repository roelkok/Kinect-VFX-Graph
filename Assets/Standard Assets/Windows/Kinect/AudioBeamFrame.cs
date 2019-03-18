using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioBeamFrame
    //
    public sealed partial class AudioBeamFrame : RootSystem.IDisposable, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal AudioBeamFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioBeamFrame_AddRefObject(ref _pNative);
        }

        ~AudioBeamFrame()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamFrame_AddRefObject(ref RootSystem.IntPtr pNative);

        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamFrame_get_AudioBeam(RootSystem.IntPtr pNative);
        public  Windows.Kinect.AudioBeam AudioBeam
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_AudioBeamFrame_get_AudioBeam(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.AudioBeam>(objectPointer, n => new Windows.Kinect.AudioBeam(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamFrame_get_AudioSource(RootSystem.IntPtr pNative);
        public  Windows.Kinect.AudioSource AudioSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_AudioBeamFrame_get_AudioSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.AudioSource>(objectPointer, n => new Windows.Kinect.AudioSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_AudioBeamFrame_get_Duration(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan Duration
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_AudioBeamFrame_get_Duration(_pNative));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_AudioBeamFrame_get_RelativeTimeStart(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTimeStart
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamFrame");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_AudioBeamFrame_get_RelativeTimeStart(_pNative));
            }
        }


        // Public Methods
        private void __EventCleanup()
        {
        }
    }

}
