using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.AudioSource
    //
    public sealed partial class AudioSource : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal AudioSource(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_AudioSource_AddRefObject(ref _pNative);
        }

        ~AudioSource()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioSource_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioSource_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<AudioSource>(_pNative);
                Windows_Kinect_AudioSource_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_AudioSource_get_AudioBeams(RootSystem.IntPtr pNative, [RootSystem.Runtime.InteropServices.Out] RootSystem.IntPtr[] outCollection, int outCollectionSize);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern int Windows_Kinect_AudioSource_get_AudioBeams_Length(RootSystem.IntPtr pNative);
        public  RootSystem.Collections.Generic.IList<Windows.Kinect.AudioBeam> AudioBeams
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioSource");
                }

                int outCollectionSize = Windows_Kinect_AudioSource_get_AudioBeams_Length(_pNative);
                var outCollection = new RootSystem.IntPtr[outCollectionSize];
                var managedCollection = new Windows.Kinect.AudioBeam[outCollectionSize];

                outCollectionSize = Windows_Kinect_AudioSource_get_AudioBeams(_pNative, outCollection, outCollectionSize);
                Helper.ExceptionHelper.CheckLastError();
                for(int i=0;i<outCollectionSize;i++)
                {
                    if(outCollection[i] == RootSystem.IntPtr.Zero)
                    {
                        continue;
                    }

                    var obj = Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.AudioBeam>(outCollection[i], n => new Windows.Kinect.AudioBeam(n));

                    managedCollection[i] = obj;
                }
                return managedCollection;
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern bool Windows_Kinect_AudioSource_get_IsActive(RootSystem.IntPtr pNative);
        public  bool IsActive
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioSource");
                }

                return Windows_Kinect_AudioSource_get_IsActive(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_AudioSource_get_KinectSensor(RootSystem.IntPtr pNative);
        public  Windows.Kinect.KinectSensor KinectSensor
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioSource");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_AudioSource_get_KinectSensor(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.KinectSensor>(objectPointer, n => new Windows.Kinect.KinectSensor(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern uint Windows_Kinect_AudioSource_get_MaxSubFrameCount(RootSystem.IntPtr pNative);
        public  uint MaxSubFrameCount
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioSource");
                }

                return Windows_Kinect_AudioSource_get_MaxSubFrameCount(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern long Windows_Kinect_AudioSource_get_SubFrameDuration(RootSystem.IntPtr pNative);
        public  RootSystem.TimeSpan SubFrameDuration
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioSource");
                }

                return RootSystem.TimeSpan.FromMilliseconds(Windows_Kinect_AudioSource_get_SubFrameDuration(_pNative));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern uint Windows_Kinect_AudioSource_get_SubFrameLengthInBytes(RootSystem.IntPtr pNative);
        public  uint SubFrameLengthInBytes
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioSource");
                }

                return Windows_Kinect_AudioSource_get_SubFrameLengthInBytes(_pNative);
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern Windows.Kinect.KinectAudioCalibrationState Windows_Kinect_AudioSource_get_AudioCalibrationState(RootSystem.IntPtr pNative);
        public  Windows.Kinect.KinectAudioCalibrationState AudioCalibrationState
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("AudioSource");
                }

                return Windows_Kinect_AudioSource_get_AudioCalibrationState(_pNative);
            }
        }


        // Events
        private static RootSystem.Runtime.InteropServices.GCHandle _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle;
        [RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private delegate void _Windows_Kinect_FrameCapturedEventArgs_Delegate(RootSystem.IntPtr args, RootSystem.IntPtr pNative);
        private static Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Kinect.FrameCapturedEventArgs>>> Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks = new Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Kinect.FrameCapturedEventArgs>>>();
        [AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_FrameCapturedEventArgs_Delegate))]
        private static void Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler(RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<Windows.Kinect.FrameCapturedEventArgs>> callbackList = null;
            Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock(callbackList)
            {
                var objThis = Helper.NativeObjectCache.GetObject<AudioSource>(pNative);
                var args = new Windows.Kinect.FrameCapturedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioSource_add_FrameCaptured(RootSystem.IntPtr pNative, _Windows_Kinect_FrameCapturedEventArgs_Delegate eventCallback, bool unsubscribe);
        public  event RootSystem.EventHandler<Windows.Kinect.FrameCapturedEventArgs> FrameCaptured
        {
            add
            {
                Helper.EventPump.EnsureInitialized();

                Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if(callbackList.Count == 1)
                    {
                        var del = new _Windows_Kinect_FrameCapturedEventArgs_Delegate(Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler);
                        _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle = RootSystem.Runtime.InteropServices.GCHandle.Alloc(del);
                        Windows_Kinect_AudioSource_add_FrameCaptured(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    return;
                }

                Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if(callbackList.Count == 0)
                    {
                        Windows_Kinect_AudioSource_add_FrameCaptured(_pNative, Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
                        _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }

        private static RootSystem.Runtime.InteropServices.GCHandle _Windows_Data_PropertyChangedEventArgs_Delegate_Handle;
        [RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private delegate void _Windows_Data_PropertyChangedEventArgs_Delegate(RootSystem.IntPtr args, RootSystem.IntPtr pNative);
        private static Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Data.PropertyChangedEventArgs>>> Windows_Data_PropertyChangedEventArgs_Delegate_callbacks = new Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Data.PropertyChangedEventArgs>>>();
        [AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Data_PropertyChangedEventArgs_Delegate))]
        private static void Windows_Data_PropertyChangedEventArgs_Delegate_Handler(RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<Windows.Data.PropertyChangedEventArgs>> callbackList = null;
            Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock(callbackList)
            {
                var objThis = Helper.NativeObjectCache.GetObject<AudioSource>(pNative);
                var args = new Windows.Data.PropertyChangedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_AudioSource_add_PropertyChanged(RootSystem.IntPtr pNative, _Windows_Data_PropertyChangedEventArgs_Delegate eventCallback, bool unsubscribe);
        public  event RootSystem.EventHandler<Windows.Data.PropertyChangedEventArgs> PropertyChanged
        {
            add
            {
                Helper.EventPump.EnsureInitialized();

                Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Data_PropertyChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if(callbackList.Count == 1)
                    {
                        var del = new _Windows_Data_PropertyChangedEventArgs_Delegate(Windows_Data_PropertyChangedEventArgs_Delegate_Handler);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle = RootSystem.Runtime.InteropServices.GCHandle.Alloc(del);
                        Windows_Kinect_AudioSource_add_PropertyChanged(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    return;
                }

                Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Data_PropertyChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if(callbackList.Count == 0)
                    {
                        Windows_Kinect_AudioSource_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_AudioSource_OpenReader(RootSystem.IntPtr pNative);
        public Windows.Kinect.AudioBeamFrameReader OpenReader()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("AudioSource");
            }

            RootSystem.IntPtr objectPointer = Windows_Kinect_AudioSource_OpenReader(_pNative);
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.AudioBeamFrameReader>(objectPointer, n => new Windows.Kinect.AudioBeamFrameReader(n));
        }

        private void __EventCleanup()
        {
            {
                Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_FrameCapturedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                        {
                            Windows_Kinect_AudioSource_add_FrameCaptured(_pNative, Windows_Kinect_FrameCapturedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Kinect_FrameCapturedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
            {
                Windows_Data_PropertyChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Data_PropertyChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                        {
                            Windows_Kinect_AudioSource_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }
    }

}
