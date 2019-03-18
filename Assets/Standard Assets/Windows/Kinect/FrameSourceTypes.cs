using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.FrameSourceTypes
    //
    [RootSystem.Flags]
    public enum FrameSourceTypes : uint
    {
        None                                     =0,
        Color                                    =1,
        Infrared                                 =2,
        LongExposureInfrared                     =4,
        Depth                                    =8,
        BodyIndex                                =16,
        Body                                     =32,
        Audio                                    =64,
    }

}
