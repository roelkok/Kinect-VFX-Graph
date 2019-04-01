using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace KinectVfx
{
    public static class KinectVfxExtensions
    {
        static MethodInfo _SetNativeDataMethod;
        static object[] arg5 = new object[5];

        // Taken from https://github.com/keijiro/Rsvfx/blob/master/Assets/Rsvfx/Utility.cs
        //
        // Directly load an unmanaged data array to a compute buffer via an
        // Intptr. This is not a public interface so will be broken one day.
        // DO NOT TRY AT HOME.
        //
        public static void SetData(this ComputeBuffer target, IntPtr pointer, int count, int stride)
        {
            if (_SetNativeDataMethod == null)
            {
                _SetNativeDataMethod = typeof(ComputeBuffer).GetMethod("InternalSetNativeData", BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance);
            }

            arg5[0] = pointer;
            arg5[1] = 0;
            arg5[2] = 0;
            arg5[3] = count;
            arg5[4] = stride;

            _SetNativeDataMethod.Invoke(target, arg5);
        }
    }
}
