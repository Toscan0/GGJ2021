using UnityEngine;

public class EnterRoomPlayer : MonoBehaviour
{
    public float TransitionSpeed = 1f;

    [SerializeField]
    private Rigidbody2D Rigidbody;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void EnterRoom(EnterRoom enterRoom, EntranceSide entranceSide)
    {
        var collider = enterRoom.gameObject.GetComponent<Collider2D>();

        int sideModifier = entranceSide == EntranceSide.Right ? 1 : -1;

        gameObject.transform.position = new Vector3(enterRoom.transform.position.x + sideModifier * collider.bounds.size.x, enterRoom.transform.position.y, gameObject.transform.position.z);
    }


}
