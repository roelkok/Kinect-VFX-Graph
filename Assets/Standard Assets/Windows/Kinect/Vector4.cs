using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.Vector4
    //
    [RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct Vector4
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float W { get; set; }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Vector4))
            {
                return false;
            }

            return this.Equals((Vector4)obj);
        }

        public bool Equals(Vector4 obj)
        {
            return X.Equals(obj.X) && Y.Equals(obj.Y) && Z.Equals(obj.Z) && W.Equals(obj.W);
        }

        public static bool operator ==(Vector4 a, Vector4 b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Vector4 a, Vector4 b)
        {
            return !(a.Equals(b));
        }
    }

}
