using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{
    public float moveSpeed = 10;
    public float stoppingSpeed = 3;
    
    private float currentMovSpeed = 0;

    private Rigidbody2D rb;
    private Vector3 movDir;
    private bool stopMovement = false;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        stopMovement = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Light")
        {
            stopMovement = false;
            Vector3 dir = collision.transform.position - transform.position;
            dir.Normalize();
            movDir = dir;
            currentMovSpeed = moveSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        stopMovement = true;
    }

    private void FixedUpdate()
    {
        if(!stopMovement && currentMovSpeed != 0)
            MoveCharacter(movDir);
        else
        {
            currentMovSpeed -= (stoppingSpeed * Time.deltaTime);
            if(currentMovSpeed <= 0.5)
            {
                movDir = Vector3.zero;
                currentMovSpeed = 0;
                stopMovement = false;
            }
            MoveCharacter(movDir);
        }
    }

    void MoveCharacter(Vector3 direction)
    {
        if(direction != Vector3.zero)
        {
            Vector2 aux = transform.position + (direction * currentMovSpeed * Time.deltaTime);
            rb.MovePosition(aux);
        }
            
    }
}
