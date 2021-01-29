using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();    
    }

    internal void Move(float f)
    {
        rb2d.AddForce(new Vector2(f, 0), ForceMode2D.Force);
    }

    internal void Move2(Vector3 f)
    {
        transform.position += f;
    }

    internal void Jump(float jumpForce)
    {
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
