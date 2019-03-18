using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.ColorSpacePoint
    //
    [RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct ColorSpacePoint
    {
        public float X { get; set; }
        public float Y { get; set; }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ColorSpacePoint))
            {
                return false;
            }

            return this.Equals((ColorSpacePoint)obj);
        }

        public bool Equals(ColorSpacePoint obj)
        {
            return X.Equals(obj.X) && Y.Equals(obj.Y);
        }

        public static bool operator ==(ColorSpacePoint a, ColorSpacePoint b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ColorSpacePoint a, ColorSpacePoint b)
        {
            return !(a.Equals(b));
        }
    }

}
