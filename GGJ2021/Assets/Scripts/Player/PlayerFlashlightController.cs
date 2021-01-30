using System;
using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayerFlashlightController : MonoBehaviour
{
    [SerializeField]
    private GameObject flashlight;
    [SerializeField]
    private float shrinkTime = 300;
    [SerializeField]
    private float minShrinkRadius = 3;

    public float timeBeforeShrink = 2f;

    private float initialOuterRadius;
    private float currentShrinkTime;
    private bool shrinkLight = false;

    private void Start()
    {
        currentShrinkTime = shrinkTime;
        initialOuterRadius = flashlight.GetComponent<Light2D>().pointLightOuterRadius;
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
            StartCoroutine( ShrinkLight());
        }
        else
        {
            StopAllCoroutines();
            ResetValues();
        }
    }

    private void ResetValues()
    {
        currentShrinkTime = shrinkTime;
        flashlight.GetComponent<Light2D>().pointLightOuterRadius = initialOuterRadius;
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

}
