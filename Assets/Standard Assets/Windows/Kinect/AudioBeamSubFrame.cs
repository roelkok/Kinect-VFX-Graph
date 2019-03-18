using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioBeamSubFrame
    //
    public sealed partial class AudioBeamSubFrame : RootSystem.IDisposable, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal AudioBeamSubFrame(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioBeamSubFrame_AddRefObject(ref _pNative);
        }

        ~AudioBeamSubFrame()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamSubFrame_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamSubFrame_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<AudioBeamSubFrame>(_pNative);

            if (disposing)
            {
                Windows_Kinect_AudioBeamSubFrame_Dispose(_pNative);
            }
                Windows_Kinect_AudioBeamSubFrame_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.Kinect.AudioBeamMode Windows_Kinect_AudioBeamSubFrame_get_AudioBeamMode(RootSystem.IntPtr pNative);
        public  Windows.Kinect.AudioBeamMode AudioBeamMode
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
                }

                return Windows_Kinect_AudioBeamSubFrame_get_AudioBeamMode(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] RootSystem.IntPtr[] outCollection, int outCollectionSize);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations_Length(RootSystem.IntPtr pNative);
        public  RootSystem.Collections.Generic.IList<Windows.Kinect.AudioBodyCorrelation> AudioBodyCorrelations
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
                }

                int outCollectionSize = Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations_Length(_pNative);
                var outCollection = new RootSystem.IntPtr[outCollectionSize];
                var managedCollection = new Windows.Kinect.AudioBodyCorrelation[outCollectionSize];

                outCollectionSize = Windows_Kinect_AudioBeamSubFrame_get_AudioBodyCorrelations(_pNative, outCollection, outCollectionSize);
                Helper.ExceptionHelper.CheckLastError();
                for(int i=0;i<outCollectionSize;i++)
                {
                    if(outCollection[i] == RootSystem.IntPtr.Zero)
                    {
                        continue;
                    }

                    var obj = Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.AudioBodyCorrelation>(outCollection[i], n => new Windows.Kinect.AudioBodyCorrelation(n));

                    managedCollection[i] = obj;
                }
                return managedCollection;
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern float Windows_Kinect_AudioBeamSubFrame_get_BeamAngle(RootSystem.IntPtr pNative);
        public  float BeamAngle
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
                }

                return Windows_Kinect_AudioBeamSubFrame_get_BeamAngle(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern float Windows_Kinect_AudioBeamSubFrame_get_BeamAngleConfidence(RootSystem.IntPtr pNative);
        public  float BeamAngleConfidence
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
                }

                return Windows_Kinect_AudioBeamSubFrame_get_BeamAngleConfidence(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_AudioBeamSubFrame_get_Duration(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan Duration
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_AudioBeamSubFrame_get_Duration(_pNative));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern uint Windows_Kinect_AudioBeamSubFrame_get_FrameLengthInBytes(RootSystem.IntPtr pNative);
        public  uint FrameLengthInBytes
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
                }

                return Windows_Kinect_AudioBeamSubFrame_get_FrameLengthInBytes(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_AudioBeamSubFrame_get_RelativeTime(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan RelativeTime
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_AudioBeamSubFrame_get_RelativeTime(_pNative));
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToArray(RootSystem.IntPtr pNative, RootSystem.IntPtr frameData, int frameDataSize);
        public void CopyFrameDataToArray(byte[] frameData)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("AudioBeamSubFrame");
            }

            var frameDataSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(frameData, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _frameData = frameDataSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_AudioBeamSubFrame_CopyFrameDataToArray(_pNative, _frameData, frameData.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioBeamSubFrame_Dispose(RootSystem.IntPtr pNative);
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
