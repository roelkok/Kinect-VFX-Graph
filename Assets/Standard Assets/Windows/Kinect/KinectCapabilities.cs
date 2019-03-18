using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.KinectCapabilities
    //
    [RootSystem.Flags]
    public enum KinectCapabilities : uint
    {
        None                                     =0,
        Vision                                   =1,
        Audio                                    =2,
        Face                                     =4,
        Expressions                              =8,
        Gamechat                                 =16,
    }

}
