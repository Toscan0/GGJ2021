using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    public float TransitionSpeed = 1f;

    private Vector3? NextPosition = null;
    private float TransitionRate = 0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (NextPosition.HasValue) 
        {
            TransitionRate += TransitionSpeed * Time.deltaTime;

            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, NextPosition.Value, TransitionRate);

            if (Vector3.Distance(gameObject.transform.position,NextPosition.Value) < 0.1) 
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
}
