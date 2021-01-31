using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PressurePlate : MonoBehaviour
{
    [SerializeField]
    private GameObject[] particles;

    [SerializeField]
    private AudioSource AudioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach(var ps in particles)
            {
                ps.SetActive(true);
            }

            if (AudioSource != null)
            {
                AudioSource.Play();
            }
        }
    }
}