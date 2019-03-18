using RootSystem = System;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Windows.Kinect
{
    // NOTE: This uses an IBuffer under the covers, it is renamed here to give parity to our managed APIs.
    public class KinectBuffer : Helper.INativeWrapper, IDisposable
    {
        internal RootSystem.IntPtr _pNative;

        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal KinectBuffer(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Storage_Streams_IBuffer_AddRefObject(ref _pNative);
        }

        ~KinectBuffer()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention = RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private static extern void Windows_Storage_Streams_IBuffer_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention = RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private static extern void Windows_Storage_Streams_IBuffer_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            Helper.NativeObjectCache.RemoveObject<KinectBuffer>(_pNative);

            if (disposing)
            {
                Windows_Storage_Streams_IBuffer_Dispose(_pNative);
            }

            Windows_Storage_Streams_IBuffer_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention = RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError = true)]
        private static extern uint Windows_Storage_Streams_IBuffer_get_Capacity(RootSystem.IntPtr pNative);
        public uint Capacity
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectBuffer");
                }

                uint capacity = Windows_Storage_Streams_IBuffer_get_Capacity(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                return capacity;
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention = RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError = true)]
        private static extern uint Windows_Storage_Streams_IBuffer_get_Length(RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention = RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError = true)]
        private static extern void Windows_Storage_Streams_IBuffer_put_Length(RootSystem.IntPtr pNative, uint value);
        public uint Length
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectBuffer");
                }

                uint length = Windows_Storage_Streams_IBuffer_get_Length(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                return length;
            }
            set
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectBuffer");
                }

                Windows_Storage_Streams_IBuffer_put_Length(_pNative, value);
                Helper.ExceptionHelper.CheckLastError();
            }
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention = RootSystem.Runtime.InteropServices.CallingConvention.Cdecl)]
        private static extern void Windows_Storage_Streams_IBuffer_Dispose(RootSystem.IntPtr pNative);
        // Constructors and Finalizers
        public void Dispose()
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                throw new RootSystem.ObjectDisposedException("KinectBuffer");
            }

            Dispose(true);
            RootSystem.GC.SuppressFinalize(this);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention = RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError = true)]
        private static extern RootSystem.IntPtr Windows_Storage_Streams_IBuffer_get_UnderlyingBuffer(RootSystem.IntPtr pNative);
        public IntPtr UnderlyingBuffer
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("KinectBuffer");
                }

                RootSystem.IntPtr value = Windows_Storage_Streams_IBuffer_get_UnderlyingBuffer(_pNative);
                Helper.ExceptionHelper.CheckLastError();
                return value;
            }
        }
    }
}