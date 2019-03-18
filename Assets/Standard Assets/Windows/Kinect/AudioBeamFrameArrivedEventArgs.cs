using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioBeamFrameArrivedEventArgs
    //
    public sealed partial class AudioBeamFrameArrivedEventArgs : RootSystem.EventArgs, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal AudioBeamFrameArrivedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioBeamFrameArrivedEventArgs_AddRefObject(ref _pNative);
        }

        ~AudioBeamFrameArrivedEventArgs()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamFrameArrivedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamFrameArrivedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<AudioBeamFrameArrivedEventArgs>(_pNative);
                Windows_Kinect_AudioBeamFrameArrivedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_AudioBeamFrameArrivedEventArgs_get_FrameReference(RootSystem.IntPtr pNative);
        public  Windows.Kinect.AudioBeamFrameReference FrameReference
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamFrameArrivedEventArgs");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_AudioBeamFrameArrivedEventArgs_get_FrameReference(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.AudioBeamFrameReference>(objectPointer, n => new Windows.Kinect.AudioBeamFrameReference(n));
            }
        }

        private void __EventCleanup()
        {
        }
    }

}
