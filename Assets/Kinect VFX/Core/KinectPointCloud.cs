using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Profiling;
using Windows.Kinect;

namespace KinectVfx
{
    public class KinectPointCloud : MonoBehaviour
    {
        public RenderTexture PointCloudMap;
        public ComputeShader PointCloudBaker;
        public RenderTexture ColorMap;
        public bool ManageSensor = true;
        public bool UseColor = true;

        private KinectSensor sensor;
        private MultiSourceFrameReader multiSourceReader;
        private byte[] colorFrameData;
        private float[] depthToColorPoints;
        private int[] mapDimensions = new int[2];
        private ComputeBuffer positionBuffer;
        private ComputeBuffer depthToColorMapBuffer;
        private RenderTexture tempPositionTexture;
        private Texture2D colorSourceTexture;
        private RenderTexture tempColorTexture;

        void Start()
        {
            sensor = KinectSensor.GetDefault();

            if (sensor != null)
            {
                if (!sensor.IsOpen)
                {
                    sensor.Open();
                }

                var enabledFrameSourceTypes = FrameSourceTypes.Depth;
                if (UseColor)
                {
                    enabledFrameSourceTypes |= FrameSourceTypes.Color;
                    colorFrameData = new byte[sensor.ColorFrameSource.FrameDescription.LengthInPixels * 4];
                    depthToColorPoints = new float[(int)sensor.DepthFrameSource.FrameDescription.LengthInPixels * 2];
                }

                multiSourceReader = sensor.OpenMultiSourceFrameReader(enabledFrameSourceTypes);
            }
        }

        void Update()
        {
            if (multiSourceReader != null)
            {
                var frame = multiSourceReader.AcquireLatestFrame();
                if (frame != null)
                {
                    using (var depthFrame = frame.DepthFrameReference.AcquireFrame())
                    {
                        if (depthFrame != null)
                        {
                            int depthFrameWidth = depthFrame.FrameDescription.Width;
                            int depthFrameHeight = depthFrame.FrameDescription.Height;
                            int depthFramePixelCount = depthFrameWidth * depthFrameHeight;

                            float horizontalFov = depthFrame.FrameDescription.HorizontalFieldOfView;
                            float verticalFov = depthFrame.FrameDescription.VerticalFieldOfView;

                            mapDimensions[0] = depthFrameWidth;
                            mapDimensions[1] = depthFrameHeight;
                            float baseDepth = depthFrameWidth * 0.5f * Mathf.Tan(horizontalFov * (Mathf.PI / 180f) * 0.5f);

                            if (tempPositionTexture != null && (tempPositionTexture.width != depthFrameWidth || tempPositionTexture.height != depthFrameHeight))
                            {
                                Destroy(tempPositionTexture);
                                tempPositionTexture = null;
                            }

                            if (positionBuffer != null && positionBuffer.count != depthFramePixelCount)
                            {
                                positionBuffer.Dispose();
                                positionBuffer = null;
                            }

                            if (tempPositionTexture == null)
                            {
                                tempPositionTexture = new RenderTexture(depthFrameWidth, depthFrameHeight, 0, RenderTextureFormat.ARGBHalf);
                                tempPositionTexture.enableRandomWrite = true;
                                tempPositionTexture.Create();
                            }

                            if (positionBuffer == null)
                            {
                                positionBuffer = new ComputeBuffer(depthFramePixelCount / 2, sizeof(uint));
                            }

                            using (var depthBuffer = depthFrame.LockImageBuffer())
                            {
                                positionBuffer.SetData(depthBuffer.UnderlyingBuffer, depthFramePixelCount / 2, sizeof(uint));
                                int bakeDepthKernel = PointCloudBaker.FindKernel("BakeDepth");
                                PointCloudBaker.SetInts("MapDimensions", mapDimensions);
                                PointCloudBaker.SetFloat("BaseDepth", baseDepth);
                                PointCloudBaker.SetBuffer(bakeDepthKernel, "PositionBuffer", positionBuffer);
                                PointCloudBaker.SetTexture(bakeDepthKernel, "PositionTexture", tempPositionTexture);
                                PointCloudBaker.Dispatch(bakeDepthKernel, depthFrameWidth / 8, depthFrameHeight / 8, 1);
                            }

                            Graphics.CopyTexture(tempPositionTexture, PointCloudMap);

                            if (UseColor) {
                                using (var colorFrame = frame.ColorFrameReference.AcquireFrame())
                                {
                                    if (colorFrame != null)
                                    {
                                        int colorFrameWidth = colorFrame.FrameDescription.Width;
                                        int colorFrameHeight = colorFrame.FrameDescription.Height;

                                        if (colorSourceTexture != null && (colorSourceTexture.width != colorFrameWidth || colorSourceTexture.height != colorFrameHeight))
                                        {
                                            Destroy(colorSourceTexture);
                                            colorSourceTexture = null;
                                        }

                                        if (colorSourceTexture == null)
                                        {
                                            colorSourceTexture = new Texture2D(colorFrameWidth, colorFrameHeight, TextureFormat.RGBA32, false);
                                        }

                                        if (tempColorTexture != null && (tempColorTexture.width != depthFrameWidth || tempColorTexture.height != depthFrameHeight))
                                        {
                                            Destroy(tempColorTexture);
                                            tempColorTexture = null;
                                        }

                                        if (tempColorTexture == null)
                                        {
                                            tempColorTexture = new RenderTexture(depthFrameWidth, depthFrameHeight, 0, RenderTextureFormat.ARGB32);
                                            tempColorTexture.enableRandomWrite = true;
                                            tempColorTexture.Create();
                                        }

                                        if (depthToColorMapBuffer != null && depthToColorMapBuffer.count != depthFramePixelCount)
                                        {
                                            depthToColorMapBuffer.Dispose();
                                            depthToColorMapBuffer = null;
                                        }

                                        if (depthToColorMapBuffer == null)
                                        {
                                            depthToColorMapBuffer = new ComputeBuffer(depthFramePixelCount, sizeof(float) * 2);
                                        }

                                        // Map depth points to color space
                                        using (var depthBuffer = depthFrame.LockImageBuffer())
                                        {
                                            var depthToColorPointsPtr = GCHandle.Alloc(depthToColorPoints, GCHandleType.Pinned);
                                            sensor.CoordinateMapper.MapDepthFrameToColorSpaceUsingIntPtr(
                                                depthBuffer.UnderlyingBuffer,
                                                (int)sensor.DepthFrameSource.FrameDescription.LengthInPixels * sizeof(ushort),
                                                depthToColorPointsPtr.AddrOfPinnedObject(),
                                                sensor.DepthFrameSource.FrameDescription.LengthInPixels);// * sizeof(float) * 2);
                                            depthToColorMapBuffer.SetData(depthToColorPointsPtr.AddrOfPinnedObject(), depthFramePixelCount, sizeof(float) * 2);
                                            depthToColorPointsPtr.Free();
                                        }

                                        var colorDataPtr = GCHandle.Alloc(colorFrameData, GCHandleType.Pinned);
                                        colorFrame.CopyConvertedFrameDataToIntPtr(colorDataPtr.AddrOfPinnedObject(), (uint)colorFrameData.Length, ColorImageFormat.Rgba);
                                        colorSourceTexture.LoadRawTextureData(colorDataPtr.AddrOfPinnedObject(), colorFrameData.Length * sizeof(float) * 4);
                                        colorSourceTexture.Apply();
                                        colorDataPtr.Free();

                                        int bakeColorKernel = PointCloudBaker.FindKernel("BakeColor");
                                        PointCloudBaker.SetTexture(bakeColorKernel, "ColorSource", colorSourceTexture);
                                        PointCloudBaker.SetBuffer(bakeColorKernel, "DepthToColorMap", depthToColorMapBuffer); // Upload mapped points
                                        PointCloudBaker.SetTexture(bakeColorKernel, "ColorTexture", tempColorTexture);
                                        PointCloudBaker.Dispatch(bakeColorKernel, depthFrameWidth / 8, depthFrameHeight / 8, 1);

                                        Graphics.CopyTexture(tempColorTexture, ColorMap);
                                    }
                                }
                            }                            
                        }
                    }
                }
            }
        }

        private void OnDestroy()
        {
            if (sensor != null)
            {
                if (sensor.IsOpen && ManageSensor)
                {
                    sensor.Close();
                }

                sensor = null;
            }

            if (multiSourceReader != null)
            {
                multiSourceReader.Dispose();
                multiSourceReader = null;
            }

            if (positionBuffer != null)
            {
                positionBuffer.Dispose();
                positionBuffer = null;
            }

            if (tempPositionTexture != null)
            {
                Destroy(tempPositionTexture);
                tempPositionTexture = null;
            }

            if (colorSourceTexture != null) {
                Destroy(colorSourceTexture);
                colorSourceTexture = null;
            }

            if (tempColorTexture != null)
            {
                Destroy(tempColorTexture);
                tempColorTexture = null;
            }

            if (depthToColorMapBuffer != null)
            {
                depthToColorMapBuffer.Dispose();
                depthToColorMapBuffer = null;
            }
        }
    }
}

