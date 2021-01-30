using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{
    public float moveSpeed = 10;

    private Rigidbody2D rb;
    private Vector3 movDir; 
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Light")
        {
            Vector3 dir = collision.transform.position - transform.position;
            dir.Normalize();
            movDir = dir;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        movDir = Vector3.zero;
    }

    private void FixedUpdate()
    {
        MoveCharacter(movDir);
    }

    void MoveCharacter(Vector3 direction)
    {
        if(movDir != Vector3.zero)
        {
            Vector2 aux = transform.position + (direction * moveSpeed * Time.deltaTime);
            rb.MovePosition(aux);
        }
    }
}
