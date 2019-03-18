using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.CameraIntrinsics
    //
    [RootSystem.Runtime.InteropServices.StructLayout(RootSystem.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct CameraIntrinsics
    {
        public float FocalLengthX { get; set; }
        public float FocalLengthY { get; set; }
        public float PrincipalPointX { get; set; }
        public float PrincipalPointY { get; set; }
        public float RadialDistortionSecondOrder { get; set; }
        public float RadialDistortionFourthOrder { get; set; }
        public float RadialDistortionSixthOrder { get; set; }

        public override int GetHashCode()
        {
            return FocalLengthX.GetHashCode() ^ FocalLengthY.GetHashCode() ^
                PrincipalPointX.GetHashCode() ^ PrincipalPointY.GetHashCode() ^
                RadialDistortionSecondOrder.GetHashCode() ^ RadialDistortionFourthOrder.GetHashCode() ^
                RadialDistortionSixthOrder.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CameraIntrinsics))
            {
                return false;
            }

            return this.Equals((CameraIntrinsics)obj);
        }

        public bool Equals(CameraIntrinsics obj)
        {
            return FocalLengthX.Equals(obj.FocalLengthX) && FocalLengthY.Equals(obj.FocalLengthY) &&
                PrincipalPointX.Equals(obj.PrincipalPointX) && PrincipalPointY.Equals(obj.PrincipalPointY) &&
                RadialDistortionSecondOrder.Equals(obj.RadialDistortionSecondOrder) &&
                RadialDistortionFourthOrder.Equals(obj.RadialDistortionFourthOrder) &&
                RadialDistortionSixthOrder.Equals(obj.RadialDistortionSixthOrder);
        }

        public static bool operator ==(CameraIntrinsics a, CameraIntrinsics b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(CameraIntrinsics a, CameraIntrinsics b)
        {
            return !(a.Equals(b));
        }
    }

}
