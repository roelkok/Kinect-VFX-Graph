using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioBodyCorrelation
    //
    public sealed partial class AudioBodyCorrelation : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal AudioBodyCorrelation(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioBodyCorrelation_AddRefObject(ref _pNative);
        }

        ~AudioBodyCorrelation()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBodyCorrelation_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBodyCorrelation_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<AudioBodyCorrelation>(_pNative);
                Windows_Kinect_AudioBodyCorrelation_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern ulong Windows_Kinect_AudioBodyCorrelation_get_BodyTrackingId(RootSystem.IntPtr pNative);
        public  ulong BodyTrackingId
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBodyCorrelation");
                }

                return Windows_Kinect_AudioBodyCorrelation_get_BodyTrackingId(_pNative);
            }
        }

        private void __EventCleanup()
        {
        }
    }

}
