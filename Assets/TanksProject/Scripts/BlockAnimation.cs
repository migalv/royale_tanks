using UnityEngine;
using System.Collections;


public class BlockAnimation : MonoBehaviour
{
    public static float minWaitTime = 1f;
    public static float maxWaitTime = 3f;

    public bool blockIsPlaced = true;
    private float speed = 20;
    public bool hasStarted = false;
    private  Vector3 destination;
    //public GameObject levelManager;
    Vector3 distance;
    void Start()
    {
        distance = new Vector3(0, 50, 0);
        destination = gameObject.transform.position - distance;
        // Set the destination to be the object's position so it will not start off moving
        //SetDestination(destination);
    }

    void Update()
    {
        if (transform.position.y <= -40)
            Destroy(gameObject);
        if (LevelManager.LoadNextLevel && blockIsPlaced)
        {
            destination = gameObject.transform.position - distance;
            //Debug.Log("dest" + destination);
            blockIsPlaced = false;
            hasStarted = false;
            //Debug.Log("dest2" + destination);
            //Debug.Log("pos" + gameObject.transform.position);
            //StartCoroutine("LoadNextLevel");
        }

        // If the object is not at the target destination
        if (destination != gameObject.transform.position)
        {
            //print("moviendome");
            // Move towards the destination each frame until the object reaches it
            if (!hasStarted)
                StartCoroutine("Wait");
            else
                StartCoroutine("IncrementPosition");
        }
        else blockIsPlaced = true;
    }

    IEnumerator Wait()
    {   
        yield return new WaitForSeconds(Random.Range(minWaitTime, maxWaitTime));
        hasStarted = true;

    }
    IEnumerator IncrementPosition()
    {
        
        // Calculate the next position
        float delta = speed * Time.deltaTime;
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 nextPosition = Vector3.MoveTowards(currentPosition, destination, delta);

        // Move the object to the next position
        gameObject.transform.position = nextPosition;
        yield return null;
    }

    // Set the destination to cause the object to smoothly glide to the specified location
    public void SetDestination(Vector3 value)
    {
        destination = value;
    }
}
