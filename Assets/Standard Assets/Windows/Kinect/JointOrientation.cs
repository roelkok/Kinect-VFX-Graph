using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.JointOrientation
    //
    [RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct JointOrientation
    {
        public Windows.Kinect.JointType JointType { get; set; }
        public Windows.Kinect.Vector4 Orientation { get; set; }

        public override int GetHashCode()
        {
            return JointType.GetHashCode() ^ Orientation.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is JointOrientation))
            {
                return false;
            }

            return this.Equals((JointOrientation)obj);
        }

        public bool Equals(JointOrientation obj)
        {
            return JointType.Equals(obj.JointType) && Orientation.Equals(obj.Orientation);
        }

        public static bool operator ==(JointOrientation a, JointOrientation b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(JointOrientation a, JointOrientation b)
        {
            return !(a.Equals(b));
        }
    }

}
