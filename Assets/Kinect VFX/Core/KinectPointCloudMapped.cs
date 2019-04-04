using UnityEngine;
using Windows.Kinect;

public class KinectPointCloudMapped : MonoBehaviour
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
    private CameraSpacePoint[] cameraSpacePoints;

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
            cameraSpacePoints = new CameraSpacePoint[depthFrameData.Length];
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
                frame.Dispose();
                frame = null;

                sensor.CoordinateMapper.MapDepthFrameToCameraSpace(depthFrameData, cameraSpacePoints);

                mapDimensions[0] = frameWidth;
                mapDimensions[1] = frameHeight;

                if (tempPositionTexture != null && (tempPositionTexture.width != frameWidth || tempPositionTexture.height != frameHeight))
                {
                    Destroy(tempPositionTexture);
                    tempPositionTexture = null;
                }

                if (positionBuffer != null && positionBuffer.count != cameraSpacePoints.Length)
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
                    positionBuffer = new ComputeBuffer(cameraSpacePoints.Length, sizeof(float) * 3);
                }
                positionBuffer.SetData(cameraSpacePoints);

                int kernel = PointCloudBaker.FindKernel("BakeDepth");
                PointCloudBaker.SetInts("MapDimensions", mapDimensions);
                PointCloudBaker.SetBuffer(kernel, "PositionBuffer", positionBuffer);
                PointCloudBaker.SetTexture(kernel, "PositionTexture", tempPositionTexture);
                PointCloudBaker.Dispatch(kernel, frameWidth / 8, frameHeight / 8, 1);

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
