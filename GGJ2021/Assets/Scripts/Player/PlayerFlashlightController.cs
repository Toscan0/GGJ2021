using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerFlashlightController : MonoBehaviour
{
    [SerializeField]
    private GameObject flashlight;
    [SerializeField]
    private GameObject aura;
    [SerializeField]
    private float shrinkTime = 300;
    [SerializeField]
    private float minShrinkRadius = 3;
    [SerializeField]
    private float minIntensity = 0.5f;
    [SerializeField]
    private float intensityTimeShrink = 150f;
    [SerializeField]
    private float recoverySpeed = 0.5f;

    public float timeBeforeShrink = 2f;

    private float initialOuterRadius;
    private float currentShrinkTime;
    private float initialLightIntensity;
    private float currentIntensityTime;
    private bool shrinkLight = false;
    private bool resetingValues = false;

    private void Start()
    {
        currentShrinkTime = shrinkTime;
        initialOuterRadius = flashlight.GetComponent<Light2D>().pointLightOuterRadius;
        initialLightIntensity = flashlight.GetComponent<Light2D>().intensity;
        currentIntensityTime = intensityTimeShrink;
    }

    internal void ToggleFlashlight(bool turnOnOrNot)
    {
        flashlight.SetActive(turnOnOrNot);
        shrinkLight = !shrinkLight;
    }

    internal void RotateFlashlight(Vector3 mousePos)
    {
        Vector2 dir = new Vector2(mousePos.x - flashlight.transform.position.x,
            mousePos.y - flashlight.transform.position.y);

        flashlight.transform.up = dir;
    }

    private void Update()
    {
        if (shrinkLight)
        {
            StartCoroutine(ShrinkLight());
            StartCoroutine(ReduceIntensity());
        }
        else
        {
            if (!resetingValues)
            {
                StopAllCoroutines();
                StartCoroutine(ResetValues());
            }
        }
    }

    IEnumerator ReduceIntensity()
    {
        yield return new WaitForSecondsRealtime(timeBeforeShrink);
        if (currentIntensityTime > 0)
        {
            currentIntensityTime -= Time.deltaTime;
            if(flashlight.GetComponent<Light2D>().intensity > minIntensity)
            {
                flashlight.GetComponent<Light2D>().intensity = NumberConvert(currentIntensityTime, 0, 1, 0.5f , intensityTimeShrink);
            }
            if (aura.GetComponent<Light2D>().intensity > minIntensity)
            {
                aura.GetComponent<Light2D>().intensity = NumberConvert(currentIntensityTime, 0, 1, 0.5f, intensityTimeShrink);
            }
        }
    }

    IEnumerator ResetValues()
    {
        resetingValues = true;
        yield return new WaitForSecondsRealtime(0);

        if(flashlight.GetComponent<Light2D>().intensity < initialLightIntensity)
        {
            flashlight.GetComponent<Light2D>().intensity += recoverySpeed * Time.deltaTime;
        }
        if(aura.GetComponent<Light2D>().intensity < initialLightIntensity)
        {
            aura.GetComponent<Light2D>().intensity += recoverySpeed * Time.deltaTime;
        }
        if(aura.GetComponent<Light2D>().intensity >= initialLightIntensity 
            && flashlight.GetComponent<Light2D>().intensity >= initialLightIntensity)
        {
            flashlight.GetComponent<Light2D>().pointLightOuterRadius = initialOuterRadius;
            currentIntensityTime = intensityTimeShrink;
            currentShrinkTime = shrinkTime;

        }
        resetingValues = false;
    }

    IEnumerator ShrinkLight()
    {
        yield return new WaitForSecondsRealtime(timeBeforeShrink);
        if (currentShrinkTime > 0)
        {
            currentShrinkTime -= Time.deltaTime;
            if(flashlight.GetComponent<Light2D>().pointLightOuterRadius > minShrinkRadius)
                flashlight.GetComponent<Light2D>().pointLightOuterRadius = NumberConvert(currentShrinkTime);
        }
    }
    private float NumberConvert(float i)
    {
        float size = (((i - 0) * (flashlight.GetComponent<Light2D>().pointLightOuterRadius - 0)) / (shrinkTime - 0)) + 0;

        return size;
    }

    private float NumberConvert(float i, float minI, float maxR, float minR, float maxI)
    {
        float size = (((i - minI) * (maxR - minR)) / (maxI - minI)) + minR;

        return size;
    }

}
