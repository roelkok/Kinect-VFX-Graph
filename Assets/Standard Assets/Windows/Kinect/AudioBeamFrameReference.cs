using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioBeamFrameReference
    //
    public sealed partial class AudioBeamFrameReference : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal AudioBeamFrameReference(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioBeamFrameReference_AddRefObject(ref _pNative);
        }

        ~AudioBeamFrameReference()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamFrameReference_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamFrameReference_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<AudioBeamFrameReference>(_pNative);
                Windows_Kinect_AudioBeamFrameReference_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_AudioBeamFrameReference_get_RelativeTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamFrameReference");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_AudioBeamFrameReference_get_RelativeTime(_pNative));
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames_Length(RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] RootSystem.IntPtr[] outCollection, int outCollectionSize);
        public RootSystem.Collections.Generic.IList<Windows.Kinect.AudioBeamFrame> AcquireBeamFrames()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("AudioBeamFrameReference");
            }

            int outCollectionSize = Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames_Length(_pNative);
            var outCollection = new RootSystem.IntPtr[outCollectionSize];
            var managedCollection = new Windows.Kinect.AudioBeamFrame[outCollectionSize];

            outCollectionSize = Windows_Kinect_AudioBeamFrameReference_AcquireBeamFrames(_pNative, outCollection, outCollectionSize);
            Helper.ExceptionHelper.CheckLastError();
            for(int i=0;i<outCollectionSize;i++)
            {
                if(outCollection[i] == RootSystem.IntPtr.Zero)
                {
                    continue;
                }

                var obj = Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.AudioBeamFrame>(outCollection[i], n => new Windows.Kinect.AudioBeamFrame(n));

                managedCollection[i] = obj;
            }
            return managedCollection;
        }

        private void __EventCleanup()
        {
        }
    }

}
