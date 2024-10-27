using UnityEngine;

public class LightRingController : MonoBehaviour
{
    public GameObject lightRing;
    public AudioSource soundEffect;

    public void ActivateLightRing()
    {
        lightRing.SetActive(true);
        lightRing.GetComponent<Animator>().SetTrigger("Expand");
        soundEffect.Play();
    }
}
