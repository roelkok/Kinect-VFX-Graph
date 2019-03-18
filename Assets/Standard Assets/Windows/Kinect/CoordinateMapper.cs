using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.CoordinateMapper
    //
    public sealed partial class CoordinateMapper : Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal CoordinateMapper(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Kinect_CoordinateMapper_AddRefObject(ref _pNative);
        }

        ~CoordinateMapper()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<CoordinateMapper>(_pNative);
                Windows_Kinect_CoordinateMapper_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Events
        private static RootSystem.Runtime.InteropServices.GCHandle _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handle;
        [RootSystem.Runtime.InteropServices.UnmanagedFunctionPointer(RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private delegate void _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate(RootSystem.IntPtr args, RootSystem.IntPtr pNative);
        private static Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Kinect.CoordinateMappingChangedEventArgs>>> Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks = new Helper.CollectionMap<RootSystem.IntPtr, List<RootSystem.EventHandler<Windows.Kinect.CoordinateMappingChangedEventArgs>>>();
        [AOT.MonoPInvokeCallbackAttribute(typeof(_Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate))]
        private static void Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler(RootSystem.IntPtr result, RootSystem.IntPtr pNative)
        {
            List<RootSystem.EventHandler<Windows.Kinect.CoordinateMappingChangedEventArgs>> callbackList = null;
            Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.TryGetValue(pNative, out callbackList);
            lock(callbackList)
            {
                var objThis = Helper.NativeObjectCache.GetObject<CoordinateMapper>(pNative);
                var args = new Windows.Kinect.CoordinateMappingChangedEventArgs(result);
                foreach(var func in callbackList)
                {
                    Helper.EventPump.Instance.Enqueue(() => { try { func(objThis, args); } catch { } });
                }
            }
        }
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(RootSystem.IntPtr pNative, _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate eventCallback, bool unsubscribe);
        public  event RootSystem.EventHandler<Windows.Kinect.CoordinateMappingChangedEventArgs> CoordinateMappingChanged
        {
            add
            {
                Helper.EventPump.EnsureInitialized();

                Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Add(value);
                    if(callbackList.Count == 1)
                    {
                        var del = new _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate(Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler);
                        _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handle = RootSystem.Runtime.InteropServices.GCHandle.Alloc(del);
                        Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(_pNative, del, false);
                    }
                }
            }
            remove
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    return;
                }

                Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    callbackList.Remove(value);
                    if(callbackList.Count == 0)
                    {
                        Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(_pNative, Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler, true);
                        _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }


        // Public Methods
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_CoordinateMapper_MapCameraPointToDepthSpace(RootSystem.IntPtr pNative, Windows.Kinect.CameraSpacePoint cameraPoint);
        public Windows.Kinect.DepthSpacePoint MapCameraPointToDepthSpace(Windows.Kinect.CameraSpacePoint cameraPoint)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var objectPointer = Windows_Kinect_CoordinateMapper_MapCameraPointToDepthSpace(_pNative, cameraPoint);
            Helper.ExceptionHelper.CheckLastError();
            var obj = (Windows.Kinect.DepthSpacePoint)RootSystem.Runtime.InteropServices.Marshal.PtrToStructure(objectPointer, typeof(Windows.Kinect.DepthSpacePoint));
            RootSystem.Runtime.InteropServices.Marshal.FreeHGlobal(objectPointer);
            return obj;
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_CoordinateMapper_MapCameraPointToColorSpace(RootSystem.IntPtr pNative, Windows.Kinect.CameraSpacePoint cameraPoint);
        public Windows.Kinect.ColorSpacePoint MapCameraPointToColorSpace(Windows.Kinect.CameraSpacePoint cameraPoint)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var objectPointer = Windows_Kinect_CoordinateMapper_MapCameraPointToColorSpace(_pNative, cameraPoint);
            Helper.ExceptionHelper.CheckLastError();
            var obj = (Windows.Kinect.ColorSpacePoint)RootSystem.Runtime.InteropServices.Marshal.PtrToStructure(objectPointer, typeof(Windows.Kinect.ColorSpacePoint));
            RootSystem.Runtime.InteropServices.Marshal.FreeHGlobal(objectPointer);
            return obj;
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_CoordinateMapper_MapDepthPointToCameraSpace(RootSystem.IntPtr pNative, Windows.Kinect.DepthSpacePoint depthPoint, ushort depth);
        public Windows.Kinect.CameraSpacePoint MapDepthPointToCameraSpace(Windows.Kinect.DepthSpacePoint depthPoint, ushort depth)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var objectPointer = Windows_Kinect_CoordinateMapper_MapDepthPointToCameraSpace(_pNative, depthPoint, depth);
            Helper.ExceptionHelper.CheckLastError();
            var obj = (Windows.Kinect.CameraSpacePoint)RootSystem.Runtime.InteropServices.Marshal.PtrToStructure(objectPointer, typeof(Windows.Kinect.CameraSpacePoint));
            RootSystem.Runtime.InteropServices.Marshal.FreeHGlobal(objectPointer);
            return obj;
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Kinect_CoordinateMapper_MapDepthPointToColorSpace(RootSystem.IntPtr pNative, Windows.Kinect.DepthSpacePoint depthPoint, ushort depth);
        public Windows.Kinect.ColorSpacePoint MapDepthPointToColorSpace(Windows.Kinect.DepthSpacePoint depthPoint, ushort depth)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var objectPointer = Windows_Kinect_CoordinateMapper_MapDepthPointToColorSpace(_pNative, depthPoint, depth);
            Helper.ExceptionHelper.CheckLastError();
            var obj = (Windows.Kinect.ColorSpacePoint)RootSystem.Runtime.InteropServices.Marshal.PtrToStructure(objectPointer, typeof(Windows.Kinect.ColorSpacePoint));
            RootSystem.Runtime.InteropServices.Marshal.FreeHGlobal(objectPointer);
            return obj;
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapCameraPointsToDepthSpace(RootSystem.IntPtr pNative, RootSystem.IntPtr cameraPoints, int cameraPointsSize, RootSystem.IntPtr depthPoints, int depthPointsSize);
        public void MapCameraPointsToDepthSpace(Windows.Kinect.CameraSpacePoint[] cameraPoints, Windows.Kinect.DepthSpacePoint[] depthPoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var cameraPointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(cameraPoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _cameraPoints = cameraPointsSmartGCHandle.AddrOfPinnedObject();
            var depthPointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depthPoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depthPoints = depthPointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapCameraPointsToDepthSpace(_pNative, _cameraPoints, cameraPoints.Length, _depthPoints, depthPoints.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapCameraPointsToColorSpace(RootSystem.IntPtr pNative, RootSystem.IntPtr cameraPoints, int cameraPointsSize, RootSystem.IntPtr colorPoints, int colorPointsSize);
        public void MapCameraPointsToColorSpace(Windows.Kinect.CameraSpacePoint[] cameraPoints, Windows.Kinect.ColorSpacePoint[] colorPoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var cameraPointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(cameraPoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _cameraPoints = cameraPointsSmartGCHandle.AddrOfPinnedObject();
            var colorPointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(colorPoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _colorPoints = colorPointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapCameraPointsToColorSpace(_pNative, _cameraPoints, cameraPoints.Length, _colorPoints, colorPoints.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthPointsToCameraSpace(RootSystem.IntPtr pNative, RootSystem.IntPtr depthPoints, int depthPointsSize, RootSystem.IntPtr depths, int depthsSize, RootSystem.IntPtr cameraPoints, int cameraPointsSize);
        public void MapDepthPointsToCameraSpace(Windows.Kinect.DepthSpacePoint[] depthPoints, ushort[] depths, Windows.Kinect.CameraSpacePoint[] cameraPoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var depthPointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depthPoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depthPoints = depthPointsSmartGCHandle.AddrOfPinnedObject();
            var depthsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depths, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depths = depthsSmartGCHandle.AddrOfPinnedObject();
            var cameraPointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(cameraPoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _cameraPoints = cameraPointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapDepthPointsToCameraSpace(_pNative, _depthPoints, depthPoints.Length, _depths, depths.Length, _cameraPoints, cameraPoints.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthPointsToColorSpace(RootSystem.IntPtr pNative, RootSystem.IntPtr depthPoints, int depthPointsSize, RootSystem.IntPtr depths, int depthsSize, RootSystem.IntPtr colorPoints, int colorPointsSize);
        public void MapDepthPointsToColorSpace(Windows.Kinect.DepthSpacePoint[] depthPoints, ushort[] depths, Windows.Kinect.ColorSpacePoint[] colorPoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var depthPointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depthPoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depthPoints = depthPointsSmartGCHandle.AddrOfPinnedObject();
            var depthsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depths, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depths = depthsSmartGCHandle.AddrOfPinnedObject();
            var colorPointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(colorPoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _colorPoints = colorPointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapDepthPointsToColorSpace(_pNative, _depthPoints, depthPoints.Length, _depths, depths.Length, _colorPoints, colorPoints.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpace(RootSystem.IntPtr pNative, RootSystem.IntPtr depthFrameData, int depthFrameDataSize, RootSystem.IntPtr cameraSpacePoints, int cameraSpacePointsSize);
        public void MapDepthFrameToCameraSpace(ushort[] depthFrameData, Windows.Kinect.CameraSpacePoint[] cameraSpacePoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var depthFrameDataSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depthFrameData, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depthFrameData = depthFrameDataSmartGCHandle.AddrOfPinnedObject();
            var cameraSpacePointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(cameraSpacePoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _cameraSpacePoints = cameraSpacePointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapDepthFrameToCameraSpace(_pNative, _depthFrameData, depthFrameData.Length, _cameraSpacePoints, cameraSpacePoints.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpace(RootSystem.IntPtr pNative, RootSystem.IntPtr depthFrameData, int depthFrameDataSize, RootSystem.IntPtr colorSpacePoints, int colorSpacePointsSize);
        public void MapDepthFrameToColorSpace(ushort[] depthFrameData, Windows.Kinect.ColorSpacePoint[] colorSpacePoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var depthFrameDataSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depthFrameData, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depthFrameData = depthFrameDataSmartGCHandle.AddrOfPinnedObject();
            var colorSpacePointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(colorSpacePoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _colorSpacePoints = colorSpacePointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapDepthFrameToColorSpace(_pNative, _depthFrameData, depthFrameData.Length, _colorSpacePoints, colorSpacePoints.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpace(RootSystem.IntPtr pNative, RootSystem.IntPtr depthFrameData, int depthFrameDataSize, RootSystem.IntPtr depthSpacePoints, int depthSpacePointsSize);
        public void MapColorFrameToDepthSpace(ushort[] depthFrameData, Windows.Kinect.DepthSpacePoint[] depthSpacePoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var depthFrameDataSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depthFrameData, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depthFrameData = depthFrameDataSmartGCHandle.AddrOfPinnedObject();
            var depthSpacePointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depthSpacePoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depthSpacePoints = depthSpacePointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapColorFrameToDepthSpace(_pNative, _depthFrameData, depthFrameData.Length, _depthSpacePoints, depthSpacePoints.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpace(RootSystem.IntPtr pNative, RootSystem.IntPtr depthFrameData, int depthFrameDataSize, RootSystem.IntPtr cameraSpacePoints, int cameraSpacePointsSize);
        public void MapColorFrameToCameraSpace(ushort[] depthFrameData, Windows.Kinect.CameraSpacePoint[] cameraSpacePoints)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("CoordinateMapper");
            }

            var depthFrameDataSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(depthFrameData, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _depthFrameData = depthFrameDataSmartGCHandle.AddrOfPinnedObject();
            var cameraSpacePointsSmartGCHandle = new Helper.SmartGCHandle(RootSystem.Runtime.InteropServices.GCHandle.Alloc(cameraSpacePoints, RootSystem.Runtime.InteropServices.GCHandleType.Pinned));
            var _cameraSpacePoints = cameraSpacePointsSmartGCHandle.AddrOfPinnedObject();
            Windows_Kinect_CoordinateMapper_MapColorFrameToCameraSpace(_pNative, _depthFrameData, depthFrameData.Length, _cameraSpacePoints, cameraSpacePoints.Length);
            Helper.ExceptionHelper.CheckLastError();
        }

        private void __EventCleanup()
        {
            {
                Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks.TryAddDefault(_pNative);
                var callbackList = Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_callbacks[_pNative];
                lock (callbackList)
                {
                    if (callbackList.Count > 0)
                    {
                        callbackList.Clear();
                        if (_pNative != RootSystem.IntPtr.Zero)
                        {
                            Windows_Kinect_CoordinateMapper_add_CoordinateMappingChanged(_pNative, Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handler, true);
                        }
                        _Windows_Kinect_CoordinateMappingChangedEventArgs_Delegate_Handle.Free();
                    }
                }
            }
        }
    }

}
