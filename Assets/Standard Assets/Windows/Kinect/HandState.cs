using RootSystem = System;
using System.Linq;
using System.Collections.Generic;
namespace Windows.Kinect
{
    //
    // Windows.Kinect.HandState
    //
    public enum HandState : int
    {
        Unknown                                  =0,
        NotTracked                               =1,
        Open                                     =2,
        Closed                                   =3,
        Lasso                                    =4,
    }

}
