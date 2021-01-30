using UnityEngine;

public class PlayerFlashlightController : MonoBehaviour
{
    [SerializeField]
    private GameObject flashlight;

    internal void ToggleFlashlight(bool turnOn)
    {
        flashlight.SetActive(turnOn);
    }
}
