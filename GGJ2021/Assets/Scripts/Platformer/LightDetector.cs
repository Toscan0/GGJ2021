using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal; 


public class LightDetector : MonoBehaviour
{
    [SerializeField]
    private GameObject platformerLight;
    [SerializeField]
    private float timer = 2;
    [SerializeField]
    private float lightIntensity = 1;

    private float timerLock;
    private bool isLightOn = false;
    private bool turnOff = false;

    private new Light2D light;

    private void Awake()
    {
        light = platformerLight.GetComponent<Light2D>();
    }

    private void Start()
    {
        timerLock = timer;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Light")
        {
            isLightOn = true;
            turnOff = false;

            platformerLight.SetActive(true);
            light.intensity = lightIntensity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Light")
        {
            turnOff = true;
        }
    }

    private void Update()
    {
        if (turnOff)
        {
            FadeOutLight();
        }
    }

    private void FadeOutLight()
    {
        if (timerLock > 0)
        {
            timerLock -= Time.deltaTime;

            light.intensity = NumberConvert(timerLock);
        }
        else
        {
            // Reset Timer
            timerLock = timer;

            light.intensity = 0;

            turnOff = false;
            isLightOn = false;
        }
    }

    private float NumberConvert(float i)
    {
        float size = (((i - 0) * (lightIntensity - 0)) / (timer - 0)) + 0;

        return size;
    }
}