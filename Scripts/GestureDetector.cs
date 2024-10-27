using UnityEngine; // 引入UnityEngine命名空间
using Windows.Kinect;  // 引入Windows.Kinect命名空间


public class GestureDetector : MonoBehaviour // 定义GestureDetector类，继承自MonoBehaviour

{
    public LightRingController lightRingController;  // 定义LightRingController对象
    private KinectManager kinectManager;  // 定义KinectManager对象


    void Start()  // 定义Start方法

    {
        kinectManager = FindObjectOfType<KinectManager>();  // 获取KinectManager对象

    }

    void Update()  // 定义Update方法
    {
        if (kinectManager.bodies != null)  // 如果KinectManager对象的Body数组不为空

        {
            foreach (var body in kinectManager.bodies) // 遍历KinectManager对象的Body数组
            {
                if (body != null && body.IsTracked) // 如果Body对象不为空且已跟踪

                {
                    // 检测手势，例如手掌握拳
                    if (IsFistClosed(body))
                    {
                        lightRingController.ActivateLightRing();// 调用LightRingController对象的ActivateLightRing方法
                    }
                }
            }
        }
    }

    private bool IsFistClosed(Body body) // 定义IsFistClosed方法，判断手是否闭合

    {
        // 简单示例，检测手的状态
        return body.HandLeftState == HandState.Closed || body.HandRightState == HandState.Closed; // 如果左手上的状态为闭合或右手上的状态为闭合，则返回true，否则返回false

    }
}
