using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Data
{
    //
    // Windows.Data.PropertyChangedEventArgs
    //
    public sealed partial class PropertyChangedEventArgs : RootSystem.EventArgs, Helper.INativeWrapper

    {
        internal RootSystem.IntPtr _pNative;
        RootSystem.IntPtr Helper.INativeWrapper.nativePtr { get { return _pNative; } }

        // Constructors and Finalizers
        internal PropertyChangedEventArgs(RootSystem.IntPtr pNative)
        {
            _pNative = pNative;
            Windows_Data_PropertyChangedEventArgs_AddRefObject(ref _pNative);
        }

        ~PropertyChangedEventArgs()
        {
            Dispose(false);
        }

        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Data_PropertyChangedEventArgs_ReleaseObject(ref RootSystem.IntPtr pNative);
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern void Windows_Data_PropertyChangedEventArgs_AddRefObject(ref RootSystem.IntPtr pNative);
        private void Dispose(bool disposing)
        {
            if (_pNative == RootSystem.IntPtr.Zero)
            {
                return;
            }

            __EventCleanup();

            Helper.NativeObjectCache.RemoveObject<PropertyChangedEventArgs>(_pNative);
                Windows_Data_PropertyChangedEventArgs_ReleaseObject(ref _pNative);

            _pNative = RootSystem.IntPtr.Zero;
        }


        // Public Properties
        [RootSystem.Runtime.InteropServices.DllImport("KinectUnityAddin", CallingConvention=RootSystem.Runtime.InteropServices.CallingConvention.Cdecl, SetLastError=true)]
        private static extern RootSystem.IntPtr Windows_Data_PropertyChangedEventArgs_get_PropertyName(RootSystem.IntPtr pNative);
        public  string PropertyName
        {
            get
            {
                if (_pNative == RootSystem.IntPtr.Zero)
                {
                    throw new RootSystem.ObjectDisposedException("PropertyChangedEventArgs");
                }

                RootSystem.IntPtr objectPointer = Windows_Data_PropertyChangedEventArgs_get_PropertyName(_pNative);
                Helper.ExceptionHelper.CheckLastError();

                var managedString = RootSystem.Runtime.InteropServices.Marshal.PtrToStringUni(objectPointer);
                RootSystem.Runtime.InteropServices.Marshal.FreeCoTaskMem(objectPointer);
                return managedString;
            }
        }

        private void __EventCleanup()
        {
        }
    }

}
