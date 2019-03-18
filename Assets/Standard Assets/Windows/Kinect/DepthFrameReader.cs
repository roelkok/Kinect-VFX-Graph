using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.DepthFrameReader
    //
    public sealed partial class DepthFrameReader : RootSystem.IDisposable, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal DepthFrameReader(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_DepthFrameReader_AddRefObject(ref _pNative);
        }

        ~DepthFrameReader()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrameReader_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrameReader_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<DepthFrameReader>(_pNative);

            if (disposing)
            {
                Windows_Kinect_DepthFrameReader_Dispose(_pNative);
            }
                Windows_Kinect_DepthFrameReader_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameReader_get_DepthFrameSource(RootSystem.IntPtr pNative);
        public  Windows.Kinect.DepthFrameSource DepthFrameSource
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("DepthFrameReader");
                }

                RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrameReader_get_DepthFrameSource(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                if (objectPointer == RootSystem.IntPtr.Zero)
                {
                    return null;
                }

                return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.DepthFrameSource>(objectPointer, n => new Windows.Kinect.DepthFrameSource(n));
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern bool Windows_Kinect_DepthFrameReader_get_IsPaused(RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrameReader_put_IsPaused(RootSystem.IntPtr pNative, bool isPaused);
        public  bool IsPaused
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("DepthFrameReader");
                }

                return Windows_Kinect_DepthFrameReader_get_IsPaused(_pNative);
            }
            set
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("DepthFrameReader");
                }

                Windows_Kinect_DepthFrameReader_put_IsPaused(_pNative, value);
                Helper.ExceptionHelper.CheckLastError();
            }
        }


        // Events
        private static RootSystem.Runtime.InteropServices.GCHandle _Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handle;
        [RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private delegate void _Windows_Kinect_DepthFrameArrivedEventArgs_Delegate(RootSystem.IntPtr args, RootSystem.IntPtr pNative);
        private static Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Kinect.DepthFrameArrivedEventArgs>>> Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks = new Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Kinect.DepthFrameArrivedEventArgs>>>();
        [AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_DepthFrameArrivedEventArgs_Delegate))]
        private static void Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handler(RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<Windows.Kinect.DepthFrameArrivedEventArgs>> callbackList = null;
            Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock(callbackList)
            {
                var objThis = Helper.NativeObjectCache.GetObject<DepthFrameReader>(pNative);
                var args = new Windows.Kinect.DepthFrameArrivedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrameReader_add_FrameArrived(RootSystem.IntPtr pNative, _Windows_Kinect_DepthFrameArrivedEventArgs_Delegate eventCallback, bool unsubscribe);
        public  event RootSystem.EventHandler<Windows.Kinect.DepthFrameArrivedEventArgs> FrameArrived
        {
            add
            {
                Helper.EventPump.EnsureInitialized();

                Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if(callbackList.Count == 1)
                    {
                        var del = new _Windows_Kinect_DepthFrameArrivedEventArgs_Delegate(Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handler);
                        _Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handle = RootSystem.Runtime.InteropServices.GCHandle.Alloc(del);
                        Windows_Kinect_DepthFrameReader_add_FrameArrived(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    return;
                }

                Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if(callbackList.Count == 0)
                    {
                        Windows_Kinect_DepthFrameReader_add_FrameArrived(_pNative, Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handler, true);
                        _Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handle.Free();
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
                var objThis = Helper.NativeObjectCache.GetObject<DepthFrameReader>(pNative);
                var args = new Windows.Data.PropertyChangedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrameReader_add_PropertyChanged(RootSystem.IntPtr pNative, _Windows_Data_PropertyChangedEventArgs_Delegate eventCallback, bool unsubscribe);
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
                        Windows_Kinect_DepthFrameReader_add_PropertyChanged(_pNative, del, false);
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
                        Windows_Kinect_DepthFrameReader_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_DepthFrameReader_AcquireLatestFrame(RootSystem.IntPtr pNative);
        public Windows.Kinect.DepthFrame AcquireLatestFrame()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("DepthFrameReader");
            }

            RootSystem.IntPtr objectPointer = Windows_Kinect_DepthFrameReader_AcquireLatestFrame(_pNative);
            Helper.ExceptionHelper.CheckLastError();
            if (objectPointer == RootSystem.IntPtr.Zero)
            {
                return null;
            }

            return Helper.NativeObjectCache.CreateOrGetObject<Windows.Kinect.DepthFrame>(objectPointer, n => new Windows.Kinect.DepthFrame(n));
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_DepthFrameReader_Dispose(RootSystem.IntPtr pNative);
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
                Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                        {
                            Windows_Kinect_DepthFrameReader_add_FrameArrived(_pNative, Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Kinect_DepthFrameArrivedEventArgs_Delegate_Handle.Free();
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
                            Windows_Kinect_DepthFrameReader_add_PropertyChanged(_pNative, Windows_Data_PropertyChangedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Data_PropertyChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }
    }

}
