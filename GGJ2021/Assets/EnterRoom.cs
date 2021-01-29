using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    [SerializeField]
    private GameObject NextRoom;

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

    public void GoTo() 
    {
        var currentRoom = Camera.main.GetComponent<CurrentRoom>();

        currentRoom.EnterRoom(NextRoom.gameObject.transform.position);
    }
}
