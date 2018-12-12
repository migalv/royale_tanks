using UnityEngine;
using System.Collections;


public class BlockAnimation : MonoBehaviour
{
    //Variables para controlar el tiempo que espera un bloque hasta caer
    public static float minWaitTime = 1f;
    public static float maxWaitTime = 3f;

    //Flag para saber si un bloque esta colocado
    public bool blockIsPlaced = true;

    //Velocidad a la que caen los bloques
    private float speed = 20;

    //Flag para saber si el bloque empieza a caer
    public bool hasStarted = false;

    //Vector que representa la posicion destino del bloque
    private  Vector3 destination;

    //Vector que representa la distancia a la posicion objetivo
    Vector3 distance;


    void Start()
    {
        //Seteamos la distancia a 50 unidades en el eje y por debajo de la posicion actuar, 
        // para que los bloques tengan eefecto de caida
        distance = new Vector3(0, 50, 0);
        destination = gameObject.transform.position - distance;

        //SetDestination(destination);
    }

    void Update()
    {
        //Condicion para limpiar los niveles que no sean necesarios
        if (transform.position.y <= -50f)
            Destroy(gameObject);

        //
        if (LevelManager.LoadNextLevel && blockIsPlaced)
        {
            destination = gameObject.transform.position - distance;

            blockIsPlaced = false;
            hasStarted = false;

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
