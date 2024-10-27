using UnityEngine;//导入Unity引擎
using Windows.Kinect;//导入Kinect2.0的SDK

public class KinectManager : MonoBehaviour  //定义KinectManager类，继承自MonoBehaviour
{
    private KinectSensor sensor; //定义KinectSensor对象

    private BodyFrameReader bodyFrameReader;  //定义BodyFrameReader对象

    private Body[] bodies = null;  //定义Body数组


    void Start()  //定义Start方法
    {
        sensor = KinectSensor.GetDefault();  //获取默认的KinectSensor对象

        if (sensor != null)  //如果KinectSensor对象不为空

        {
            bodyFrameReader = sensor.BodyFrameSource.OpenReader();  //打开BodyFrameReader对象

            sensor.Open(); //打开KinectSensor对象

        }
    }

    void Update() //定义Update方法
    {
        if (bodyFrameReader != null)  //如果BodyFrameReader对象不为空

        {
            var frame = bodyFrameReader.AcquireLatestFrame(); //获取最新的BodyFrame对象

            if (frame != null) //如果BodyFrame对象不为空
            {
                if (bodies == null) //如果Body数组为空
                {
                    bodies = new Body[sensor.BodyFrameSource.BodyCount]; //初始化Body数组

                }
                frame.GetAndRefreshBodyData(bodies); //获取BodyFrame对象的数据
                frame.Dispose(); //释放BodyFrame对象
                frame = null; //将BodyFrame对象置为空
            }
        }
    }

    void OnApplicationQuit() //定义OnApplicationQuit方法

    {
        if (bodyFrameReader != null) //如果BodyFrameReader对象不为空
        {
            bodyFrameReader.Dispose(); //释放BodyFrameReader对象

            bodyFrameReader = null; //将BodyFrameReader对象置为空
        }
        
        if (sensor != null) //如果KinectSensor对象不为空
        {
            if (sensor.IsOpen) //如果KinectSensor对象已打开

            {
                sensor.Close(); //关闭KinectSensor对象

            }
            sensor = null; //将KinectSensor对象置为空

        }
    }
}
