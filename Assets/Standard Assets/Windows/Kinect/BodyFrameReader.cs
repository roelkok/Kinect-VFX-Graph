using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.BodyFrameReader
    //
    public sealed partial class BodyFrameReader : RootSystem.IDisposable, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal BodyFrameReader(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_BodyFrameReader_AddRefObject(ref _pNative);
        }

        ~BodyFrameReader()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<BodyFrameReader>(_pNative);

            if (disposing)
            {
                Windows_Kinect_BodyFrameReader_Dispose(_pNative);
            }
                Windows_Kinect_BodyFrameReader_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameReader_get_BodyFrameSource(RootSystem.IntPtr pNative);
        public  Windows.Kinect.BodyFrameSource BodyFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyFrameReader");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrameReader_get_BodyFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.BodyFrameSource>(objectPointer, n => new Windows.Kinect.BodyFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern bool Windows_Kinect_BodyFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
        public  bool IsPaused
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyFrameReader");
                }

                return Windows_Kinect_BodyFrameReader_get_IsPaused(_pNative);
            }
            set
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("BodyFrameReader");
                }

                Windows_Kinect_BodyFrameReader_put_IsPaused(_pNative, value);
                Helper.ExceptionHelper.CheckLastError();
            }
        }


        // Events
        private static RootSystem.Runtime.InteropServices.GCHandle _Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handle;
        [RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private delegate void _Windows_Kinect_BodyFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args, RootSystem.IntPtr pNative);
        private static Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Kinect.BodyFrameArrivedEventArgs>>> Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks = new Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Kinect.BodyFrameArrivedEventArgs>>>();
        [AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_BodyFrameArrivedEventArgs_Delegate))]
        private static void Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<Windows.Kinect.BodyFrameArrivedEventArgs>> callbackList = null;
            Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock(callbackList)
            {
                var objThis = Helper.NativeObjectCache.GetObject<BodyFrameReader>(pNative);
                var args = new Windows.Kinect.BodyFrameArrivedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyFrameReader_add_FrameArrived(RootSystem.IntPtr pNative, _Windows_Kinect_BodyFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
        public  event RootSystem.EventHandler<Windows.Kinect.BodyFrameArrivedEventArgs> FrameArrived
        {
            add
            {
                Helper.EventPump.EnsureInitialized();

                Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if(callbackList.Count == 1)
                    {
                        var del = new _Windows_Kinect_BodyFrameArrivedEventArgs_Delegate(Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handler);
                        _Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handle = RootSystem.Runtime.InteropServices.GCHandle.Alloc(del);
                        Windows_Kinect_BodyFrameReader_add_FrameArrived(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    return;
                }

                Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if(callbackList.Count == 0)
                    {
                        Windows_Kinect_BodyFrameReader_add_FrameArrived(_pNative, Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handler, true);
                        _Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handle.Free();
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
                var objThis = Helper.NativeObjectCache.GetObject<BodyFrameReader>(pNative);
                var args = new Windows.Data.PropertyChangedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyFrameReader_add_PropertyChanged(RootSystem.IntPtr pNative, _Windows_Data_PropertyChangedEventArgs_Delegate eventCallback, bool unsubscribe);
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
                        Windows_Kinect_BodyFrameReader_add_PropertyChanged(_pNative, del, false);
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
                        Windows_Kinect_BodyFrameReader_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_BodyFrameReader_AcquireLatestFrame(RootSystem.IntPtr pNative);
        public Windows.Kinect.BodyFrame AcquireLatestFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("BodyFrameReader");
            }

            RootSystem.IntPtr objectPointer = Windows_Kinect_BodyFrameReader_AcquireLatestFrame(_pNative);
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.BodyFrame>(objectPointer, n => new Windows.Kinect.BodyFrame(n));
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_BodyFrameReader_Dispose(RootSystem.IntPtr pNative);
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
            {
                Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                        {
                            Windows_Kinect_BodyFrameReader_add_FrameArrived(_pNative, Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Kinect_BodyFrameArrivedEventArgs_Delegate_Handle.Free();
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
                            Windows_Kinect_BodyFrameReader_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }
    }

}
