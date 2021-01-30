using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
        rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }
}
