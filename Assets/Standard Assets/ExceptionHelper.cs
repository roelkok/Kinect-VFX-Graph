using System;
using System.Runtime.InteropServices;

namespace Helper
{
    public static class ExceptionHelper
    {
        private const int E_NOTIMPL = unchecked((int)0x80004001);
        private const int E_OUTOFMEMORY = unchecked((int)0x8007000E);
        private const int E_INVALIDARG = unchecked((int)0x80070057);
        private const int E_POINTER = unchecked((int) 0x80004003);
        private const int E_PENDING = unchecked((int)0x8000000A);
        private const int E_FAIL = unchecked((int)0x80004005);

        public static void CheckLastError()
        {
            int hr = Marshal.GetLastWin32Error();

            if ((hr == E_PENDING) || (hr == E_FAIL))
            {
                // Ignore E_PENDING/E_FAIL - We use this to indicate no pending or missed frames
                return;
            }

            if (hr < 0)
            {
                Exception exception = Marshal.GetExceptionForHR(hr);
                string message = string.Format("This API has returned an exception from an HRESULT: 0x{0:X}", hr);

                switch (hr)
                {
                    case E_NOTIMPL:
                        throw new NotImplementedException(message, exception);

                    case E_OUTOFMEMORY:
                        throw new OutOfMemoryException(message, exception);

                    case E_INVALIDARG:
                        throw new ArgumentException(message, exception);

                    case E_POINTER:
                        throw new ArgumentNullException(message, exception);

                    default:
                        throw new InvalidOperationException(message, exception);
                }
            }
        }
    }
}