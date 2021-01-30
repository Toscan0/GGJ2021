using UnityEngine;

public class LightParticleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject roomLight;

    public void LightTheRoom()
    {
        roomLight.SetActive(true);
    }
}
