using UnityEngine;
using Windows.Kinect;

public class KinectManager : MonoBehaviour
{
    private KinectSensor sensor;
    private BodyFrameReader bodyFrameReader;
    private Body[] bodies = null;

    void Start()
    {
        sensor = KinectSensor.GetDefault();
        if (sensor != null)
        {
            bodyFrameReader = sensor.BodyFrameSource.OpenReader();
            sensor.Open();
        }
    }

    void Update()
    {
        if (bodyFrameReader != null)
        {
            var frame = bodyFrameReader.AcquireLatestFrame();
            if (frame != null)
            {
                if (bodies == null)
                {
                    bodies = new Body[sensor.BodyFrameSource.BodyCount];
                }
                frame.GetAndRefreshBodyData(bodies);
                frame.Dispose();
                frame = null;
            }
        }
    }

    void OnApplicationQuit()
    {
        if (bodyFrameReader != null)
        {
            bodyFrameReader.Dispose();
            bodyFrameReader = null;
        }
        
        if (sensor != null)
        {
            if (sensor.IsOpen)
            {
                sensor.Close();
            }
            sensor = null;
        }
    }
}
