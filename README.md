# Kinect VFX Graph

This is an example of how to use the depth camera feed from the Kinect with Unity's VFX Graph. The code in this project is heavily inspired by [Rsvfx](https://github.com/keijiro/Rsvfx) by Keijiro Takahashi.

## Requirements

- Unity version that support the VFX Graph
- The Unity package relies on the Kinect for Windows Unity package that can be downloaded separately [here](https://developer.microsoft.com/en-us/windows/kinect).

## How to use

Add the _Kinect VFX_ prefab to your scene. In your VFX Graph, use the _KinectPointCloudMap_ render texture as input for a 'Set Position From Map' node.
The color data for each depth point is available in the _KinectColorMap_ render texture.

Alternatively you can use the _Kinect VFX Mapped_ prefab instead. This does also depth mapping like the _Kinect VFX_ prefab but the internal workings are different. The positional accurancy should be slightly better but I had better performance with the _Kinect VFX_ prefab.

## TODO

- Improve the positional accuracy of the mapped points.
