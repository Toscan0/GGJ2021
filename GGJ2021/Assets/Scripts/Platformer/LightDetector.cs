using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal; 

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ShadowCaster2D))]
public class LightDetector : MonoBehaviour
{
    [SerializeField]
    private GameObject platformerLight;
    [SerializeField]
    private float timer = 2;
    [SerializeField]
    private float lightIntensity = 1;

    private float timerLock;
    private bool turnOff = false;

    private new Light2D light;
    private BoxCollider2D boxCollider2D;
    private SpriteRenderer spriteRenderer;
    private ShadowCaster2D shadowCaster2D;

    private void Awake()
    {
        light = platformerLight.GetComponent<Light2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        shadowCaster2D = GetComponent<ShadowCaster2D>();
    }

    private void Start()
    {
        timerLock = timer;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Light")
        {
            turnOff = false;

            platformerLight.SetActive(true);
            light.intensity = lightIntensity;

            boxCollider2D.isTrigger = false;
            spriteRenderer.enabled = true;
            shadowCaster2D.enabled = true;
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
            boxCollider2D.isTrigger = true;
            spriteRenderer.enabled = false;
            shadowCaster2D.enabled = false;

        }
    }

    private float NumberConvert(float i)
    {
        float size = (((i - 0) * (lightIntensity - 0)) / (timer - 0)) + 0;

        return size;
    }
}