using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;

    private float horizontalMove = 0f;
    private bool jump = false;

    public bool IsGrounded { private get; set; } = false;
    

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");

        playerMovement.Move(transform.right * horizontalMove * 
            Time.deltaTime * movementSpeed);

        if (IsGrounded && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        if (jump)
        {
            playerMovement.Jump(jumpForce);
            jump = false;
        }
    }
}
