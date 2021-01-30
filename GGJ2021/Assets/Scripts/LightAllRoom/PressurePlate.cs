using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private GameObject particles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            particles.SetActive(true);
        }
    }
}