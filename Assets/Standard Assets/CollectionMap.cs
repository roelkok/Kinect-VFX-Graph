using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    class CollectionMap<TKey, TValue> : Helper.ThreadSafeDictionary<TKey, TValue> where TValue : new()
    {
        public bool TryAddDefault(TKey key)
        {
            lock (_impl)
            {
                if (!_impl.ContainsKey(key))
                {
                    _impl.Add(key, new TValue());
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
