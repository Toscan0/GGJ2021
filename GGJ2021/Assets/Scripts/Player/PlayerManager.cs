using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerSoundManager))]
public class PlayerManager : MonoBehaviour
{
    public bool IsGrounded { private get; set; } = false;

    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private AudioClip jumpSound;

    private float horizontalMove = 0f;
    private bool jump = false;

    private PlayerMovement playerMovement;
    private PlayerSoundManager playerSoundManager;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerSoundManager = GetComponent<PlayerSoundManager>();
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
            jump = false;

            playerMovement.Jump(jumpForce);
            playerSoundManager.PlaySound(jumpSound);
        }
    }
}
