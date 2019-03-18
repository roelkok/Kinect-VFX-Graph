using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Windows.Kinect;

public class KinectPointCloud : MonoBehaviour
{
    public RenderTexture PointCloudMap;
    public ComputeShader PointCloudBaker;
    public bool ManageSensor = true;

    private KinectSensor sensor;
    private DepthFrameReader depthFrameReader;
    private ushort[] depthFrameData;
    private int[] mapDimensions = new int[2];
    private ComputeBuffer positionBuffer;
    private RenderTexture tempPositionTexture;

    void Start()
    {
        sensor = KinectSensor.GetDefault();

        if (sensor != null)
        {
            if (!sensor.IsOpen)
            {
                sensor.Open();
            }
            depthFrameReader = sensor.DepthFrameSource.OpenReader();
            depthFrameData = new ushort[sensor.DepthFrameSource.FrameDescription.LengthInPixels];
        }
    }

    void Update()
    {
        if (depthFrameReader != null)
        {
            var frame = depthFrameReader.AcquireLatestFrame();
            if (frame != null)
            {
                frame.CopyFrameDataToArray(depthFrameData);
                int frameWidth = frame.FrameDescription.Width;
                int frameHeight = frame.FrameDescription.Height;
                float horizontalFov = frame.FrameDescription.HorizontalFieldOfView;
                float verticalFov = frame.FrameDescription.VerticalFieldOfView;
                frame.Dispose();
                frame = null;

                mapDimensions[0] = frameWidth;
                mapDimensions[1] = frameHeight;
                float baseDepth = frameWidth * 0.5f * Mathf.Tan(horizontalFov * (Mathf.PI / 180f) * 0.5f);

                if (tempPositionTexture != null && (tempPositionTexture.width != frameWidth || tempPositionTexture.height != frameHeight))
                {
                    Destroy(tempPositionTexture);
                    tempPositionTexture = null;
                }

                if (positionBuffer != null && positionBuffer.count != depthFrameData.Length)
                {
                    positionBuffer.Dispose();
                    positionBuffer = null;
                }

                if (tempPositionTexture == null)
                {
                    tempPositionTexture = new RenderTexture(frameWidth, frameHeight, 0, RenderTextureFormat.ARGBHalf);
                    tempPositionTexture.enableRandomWrite = true;
                    tempPositionTexture.Create();
                }

                if (positionBuffer == null)
                {
                    positionBuffer = new ComputeBuffer(depthFrameData.Length / 2, sizeof(uint));
                }
                positionBuffer.SetData(depthFrameData);
                PointCloudBaker.SetInts("MapDimensions", mapDimensions);
                PointCloudBaker.SetFloat("BaseDepth", baseDepth);
                PointCloudBaker.SetBuffer(0, "PositionBuffer", positionBuffer);
                PointCloudBaker.SetTexture(0, "PositionTexture", tempPositionTexture);
                PointCloudBaker.Dispatch(0, frameWidth / 8, frameHeight / 8, 1);

                Graphics.CopyTexture(tempPositionTexture, PointCloudMap);
            }
        }
    }

    private void OnDestroy()
    {
        if (depthFrameReader != null)
        {
            depthFrameReader.Dispose();
            depthFrameReader = null;
        }

        if (sensor != null)
        {
            if (sensor.IsOpen && ManageSensor)
            {
                sensor.Close();
            }

            sensor = null;
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
    }
}
