using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTextAlpha : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnHighlight()
    {
        if(GetComponentInChildren<CanvasGroup>().alpha == 1)
            GetComponentInChildren<CanvasGroup>().alpha = 0;
        else
        {
            GetComponentInChildren<CanvasGroup>().alpha = 1;
        }
    }
}
