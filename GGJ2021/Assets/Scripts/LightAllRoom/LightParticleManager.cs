using UnityEngine;

[RequireComponent(typeof(Animator))]
public class LightParticleManager : MonoBehaviour
{
    [SerializeField]
    private GameObject roomLight;
    [SerializeField]
    private string triggerName;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        animator.SetTrigger(triggerName);
    }

    public void LightTheRoom()
    {
        roomLight.SetActive(true);
    }
}
