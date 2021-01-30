using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerSoundManager))]
[RequireComponent(typeof(PlayerFlashlightController))]
public class PlayerManager : MonoBehaviour
{
    public bool IsGrounded { private get; set; } = false;

    [SerializeField]
    private float movementSpeed = 5f;
    [SerializeField]
    private float jumpForce = 5f;
    [SerializeField]
    private AudioClip jumpSound;
    [SerializeField]
    private AudioClip flashlightSound;

    private float horizontalMove = 0f;
    private bool jump = false;
    private bool isFlashlightOn = false;
    private Vector3 mousePosition;

    private PlayerMovement playerMovement;
    private PlayerSoundManager playerSoundManager;
    private PlayerFlashlightController playerFlashlight;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerSoundManager = GetComponent<PlayerSoundManager>();
        playerFlashlight = GetComponent<PlayerFlashlightController>();
    }

    private void Start()
    {
        RotateFlashlight();
    }
    
    void Update()
    {
        // move player
        horizontalMove = Input.GetAxis("Horizontal");
        playerMovement.Move(transform.right * horizontalMove * 
            Time.deltaTime * movementSpeed);

        if (IsGrounded && Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Turn on/off flashlight
        if (Input.GetButtonDown("Fire1"))
        {
            isFlashlightOn = !isFlashlightOn;

            playerFlashlight.ToggleFlashlight(isFlashlightOn);
            playerSoundManager.PlaySound(flashlightSound);
        }

        // Rotate Flashlight and player
        if (isFlashlightOn)
        {
            RotateFlashlight();

            /*
             * TODO: Rotate Player
             */
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

    private void GetMousePositon()
    {
        var mousePosAux = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosAux);
    }

    private void RotateFlashlight()
    {
        GetMousePositon();
        playerFlashlight.RotateFlashlight(mousePosition);
    }
}
