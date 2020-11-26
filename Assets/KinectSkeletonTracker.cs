using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Windows.Kinect;
using KinectJoint = Windows.Kinect.Joint;

public class KinectSkeletonTracker : MonoBehaviour
{
    [SerializeField]
    private VisualEffect visualEffect;

    private KinectSensor sensor;
    private BodyFrameReader bodyFrameReader;
    private Body[] bodies;
    private ulong trackedId = ulong.MaxValue;

    private Dictionary<JointType, JointType> boneMap = new Dictionary<JointType, JointType>() {

        {JointType.FootLeft, JointType.AnkleLeft },
        {JointType.AnkleLeft, JointType.KneeLeft },
        {JointType.KneeLeft, JointType.HipLeft },
        {JointType.HipLeft, JointType.SpineBase },

        {JointType.FootRight, JointType.AnkleRight },
        {JointType.AnkleRight,JointType.KneeRight     },
        {JointType.KneeRight,JointType.HipRight },
        {JointType.HipRight,JointType.SpineBase },

        {JointType.HandLeft, JointType.WristLeft },
        {JointType.WristLeft,JointType.ElbowLeft },
        {JointType.ElbowLeft,JointType.ShoulderLeft },
        {JointType.ShoulderLeft,JointType.SpineShoulder },

        {JointType.HandRight,JointType.WristRight },
        {JointType.WristRight,JointType.ElbowRight },
        {JointType.ElbowRight,JointType.ShoulderRight },
        {JointType.ShoulderRight,JointType.SpineShoulder },

        {JointType.SpineBase,JointType.SpineMid },
        {JointType.SpineMid,JointType.SpineShoulder },
        {JointType.SpineShoulder,JointType.Head }
    };

    private Dictionary<string, JointType> jointMap = new Dictionary<string, JointType>()
    {
        { "Spine Base", JointType.SpineBase },
        { "Spine Mid", JointType.SpineMid },
        { "Spine Shoulder", JointType.SpineShoulder },
        { "Head", JointType.Head },

        { "Foot Left", JointType.FootLeft },
        { "Ankle Left", JointType.AnkleLeft },
        { "Knee Left", JointType.KneeLeft },
        { "Hip Left", JointType.HipLeft },

        { "Foot Right", JointType.FootRight },
        { "Ankle Right", JointType.AnkleRight },
        { "Knee Right", JointType.KneeRight },
        { "Hip Right", JointType.HipRight },

        { "Wrist Left", JointType.WristLeft },
        { "Elbow Left", JointType.ElbowLeft },
        { "Shoulder Left", JointType.ShoulderLeft },

        { "Wrist Right", JointType.WristRight },
        { "Elbow Right", JointType.ElbowRight },
        { "Shoulder Right", JointType.ShoulderRight }
    };

    // Start is called before the first frame update
    void Start()
    {
        sensor = KinectSensor.GetDefault();

        if (sensor != null)
        {
            bodyFrameReader = sensor.BodyFrameSource.OpenReader();

            if (!sensor.IsOpen)
            {
                sensor.Open();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (bodyFrameReader != null)
        {
            var frame = bodyFrameReader.AcquireLatestFrame();

            if (frame != null)
            {
                if (bodies == null)
                {
                    bodies = new Body[frame.BodyCount];
                }
                frame.GetAndRefreshBodyData(bodies);
                frame.Dispose();
                frame = null;

                List<ulong> trackedIds = new List<ulong>();
                foreach (var body in bodies)
                {
                    if (body == null) continue;

                    if (body.IsTracked)
                    {
                        trackedIds.Add(body.TrackingId);
                    }
                }

                if (!trackedIds.Contains(trackedId))
                {
                    if (trackedIds.Count > 0)
                    {
                        trackedId = trackedIds[0];
                    }
                    else
                    {
                        trackedId = ulong.MaxValue;
                    }
                }

                foreach (var body in bodies)
                {
                    if (body.TrackingId == trackedId)
                    {
                        foreach (var joint in jointMap)
                        {
                            visualEffect.SetVector3(joint.Key, GetVector3FromJoint(body.Joints[joint.Value]));
                        }
                        break;
                    }
                }
            }
        }
    }

    private static Vector3 GetVector3FromJoint(KinectJoint joint)
    {
        return new Vector3(joint.Position.X, joint.Position.Y, joint.Position.Z);
    }

    private void OnDestroy()
    {
        if (bodyFrameReader != null)
        {
            bodyFrameReader.Dispose();
            bodyFrameReader = null;
        }

        //if (sensor != null)
        //{

        //}
    }
}
