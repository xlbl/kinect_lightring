using UnityEngine;//导入Unity引擎

public class LightRingController : MonoBehaviour //定义LightRingController类，继承自MonoBehaviour

{
    public GameObject lightRing; //定义GameObject对象
    public AudioSource soundEffect;  //定义AudioSource对象

    public void ActivateLightRing() //定义ActivateLightRing方法
    {
        lightRing.SetActive(true);  //设置GameObject对象的激活状态为true

        lightRing.GetComponent<Animator>().SetTrigger("Expand");  //获取GameObject对象的Animator组件，并触发Expand动画

        soundEffect.Play(); //播放AudioSource对象的声音效果

    }
}
