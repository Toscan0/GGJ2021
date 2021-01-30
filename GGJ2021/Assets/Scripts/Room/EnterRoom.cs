using UnityEngine;

public enum EntranceSide
{
    Right,
    Left
}

public class EnterRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject NextRoom;
    [SerializeField]
    private GameObject NextRoomPassage;
    [SerializeField]
    private EntranceSide EntranceSide;

    public bool ChangeRoom = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Here for testing purposes
        if (ChangeRoom && NextRoom != null) 
        {
            var currentRoom = Camera.main.GetComponent<CurrentRoom>();

            currentRoom.EnterRoom(NextRoom.gameObject.transform.position);

            ChangeRoom = false;
        }
    }

    public void GoTo(GameObject gameObject) 
    {
        var player = gameObject.GetComponent<EnterRoomPlayer>();
        if (player != null) 
        {
            var currentRoom = Camera.main.GetComponent<CurrentRoom>();
            currentRoom.EnterRoom(NextRoom.gameObject.transform.position);

            player.EnterRoom(NextRoomPassage.GetComponent<EnterRoom>(), EntranceSide);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GoTo(collision.gameObject);
    }
}
