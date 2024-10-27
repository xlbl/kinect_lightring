using UnityEngine;
using Windows.Kinect;

public class GestureDetector : MonoBehaviour
{
    public LightRingController lightRingController;
    private KinectManager kinectManager;

    void Start()
    {
        kinectManager = FindObjectOfType<KinectManager>();
    }

    void Update()
    {
        if (kinectManager.bodies != null)
        {
            foreach (var body in kinectManager.bodies)
            {
                if (body != null && body.IsTracked)
                {
                    // 检测手势，例如手掌握拳
                    if (IsFistClosed(body))
                    {
                        lightRingController.ActivateLightRing();
                    }
                }
            }
        }
    }

    private bool IsFistClosed(Body body)
    {
        // 简单示例，检测手的状态
        return body.HandLeftState == HandState.Closed || body.HandRightState == HandState.Closed;
    }
}
