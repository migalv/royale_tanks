using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class BlockAnimation : MonoBehaviour
{
    private float speed = 20;
    public bool hasStarted = false;
    private  Vector3 destination;

    void Start()
    {
        Vector3 distance = new Vector3(0, 50, 0);
        destination = gameObject.transform.position - distance;
        // Set the destination to be the object's position so it will not start off moving
        SetDestination(destination);
    }

    void Update()
    {
        // If the object is not at the target destination
        if (destination != gameObject.transform.position)
        {
            // Move towards the destination each frame until the object reaches it
            if(!hasStarted)
                StartCoroutine("Wait");
            else
                StartCoroutine("IncrementPosition");
        }
    }
    IEnumerator Wait()
    {
        float test = Random.Range(1f, 3f);
        
        yield return new WaitForSeconds(test);
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
