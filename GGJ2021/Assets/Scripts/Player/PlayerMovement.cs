using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private bool falling = false;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rigidbody.velocity.y < 0)
        {
            falling = true;
            animator.SetBool("Falling", true);
        }
        else if(falling)
        {
            animator.SetBool("Falling", false);
            falling = false;
        }

    }

    internal void Move(Vector3 f)
    {
        animator.SetBool("Moving", Vector3.zero != f);

        if (f.x < 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (f.x > 0) 
        {
            spriteRenderer.flipX = true;
        }
        
        transform.position += f;
    }

    internal void Jump(float jumpForce)
    {
        animator.SetTrigger("Jumping");

        rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
