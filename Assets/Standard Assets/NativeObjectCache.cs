using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace Helper
{
    public static class NativeObjectCache
    {
        private static object _lock = new object();
        private static Dictionary<Type, Dictionary<IntPtr, WeakReference>> _objectCache = new Dictionary<Type, Dictionary<IntPtr, WeakReference>>();
        public static void AddObject<T>(IntPtr nativePtr, T obj) where T : class
        {
            lock (_lock)
            {
                Dictionary<IntPtr, WeakReference> objCache = null;

                if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }

                objCache[nativePtr] = new WeakReference(obj);
            }
        }

        public static void Flush()
        {
            lock(_lock)
            {
                foreach (var byType in _objectCache.ToArray())
                {
                    foreach(var kvp in byType.Value.ToArray())
                    {
                        IDisposable disp = kvp.Value.Target as IDisposable;
                        if(disp != null)
                        {
                            disp.Dispose();
                        }

                    }
                }
            }
        }

        public static void RemoveObject<T>(IntPtr nativePtr)
        {
            lock (_lock)
            {
                Dictionary<IntPtr, WeakReference> objCache = null;

                if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }

                if (objCache.ContainsKey(nativePtr))
                {
                    objCache.Remove(nativePtr);
                }
            }
        }

        public static T GetObject<T>(IntPtr nativePtr) where T : class
        {
            lock (_lock)
            {
                Dictionary<IntPtr, WeakReference> objCache = null;

                if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }

                WeakReference reference = null;
                if (objCache.TryGetValue(nativePtr, out reference))
                {
                    if (reference != null)
                    {
                        T obj = reference.Target as T;
                        if (obj != null)
                        {
                            return (T)obj;
                        }
                    }
                }

                return null;
            }
        }

        public static T CreateOrGetObject<T>(IntPtr nativePtr, Func<System.IntPtr,T> create) where T : class
        {
            T outputValue = null;

            lock (_lock)
            {
                Dictionary<IntPtr, WeakReference> objCache = null;

                if (!_objectCache.TryGetValue(typeof(T), out objCache) || objCache == null)
                {
                    objCache = new Dictionary<IntPtr, WeakReference>();
                    _objectCache[typeof(T)] = objCache;
                }

                WeakReference reference = null;
                if (objCache.TryGetValue(nativePtr, out reference))
                {
                    if ((reference != null) && reference.IsAlive)
                    {
                        outputValue = reference.Target as T;
                    }
                }

                if (outputValue == null)
                { 
                    if (create != null)
                    {
                        outputValue = create(nativePtr);
                        objCache[nativePtr] = new WeakReference(outputValue);
                    }
                    else if(typeof(T) == typeof(System.Object)) 
                    {
                        //T is an object, so lets just pass back our IntPtr, which is an object.
                        outputValue = (T)(System.Object)nativePtr;
                    }
                }
            }

            return outputValue;
        }
    }
}