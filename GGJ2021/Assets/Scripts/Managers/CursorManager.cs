using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField]
    private bool cursorLocked = true;

    private void Awake()
    {
        if (cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}