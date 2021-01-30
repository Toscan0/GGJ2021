using UnityEngine;

public class EnterRoomPlayer : MonoBehaviour
{
    public float TransitionSpeed = 1f;

    private Vector3? NextPosition = null;
    private float TransitionRate = 0f;

    [SerializeField]
    private Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (NextPosition.HasValue)
        {
            TransitionRate = TransitionSpeed * Time.deltaTime;

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, NextPosition.Value, TransitionRate);

            if (Vector3.Distance(gameObject.transform.position, NextPosition.Value) < 0.1)
            {
                gameObject.transform.position = NextPosition.Value;

                NextPosition = null;
            }
        }
    }

    public void EnterRoom(Vector3 position)
    {
        if (!NextPosition.HasValue)
        {
            NextPosition = new Vector3(position.x, position.y, gameObject.transform.position.z);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var passage = collision.gameObject.GetComponent<EnterRoom>();
        if (passage != null) 
        { NextPosition = null; }
    }
}
