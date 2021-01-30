using UnityEngine;

public class PlayerFlashlightController : MonoBehaviour
{
    [SerializeField]
    private GameObject flashlight;

    internal void ToggleFlashlight(bool turnOnOrNot)
    {
        flashlight.SetActive(turnOnOrNot);
    }

    internal void RotateFlashlight(Vector3 mousePos)
    {
        Vector2 dir = new Vector2(mousePos.x - flashlight.transform.position.x,
            mousePos.y - flashlight.transform.position.y);

        flashlight.transform.right = dir;
    }
}
