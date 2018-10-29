using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    //public Vector3 speed;
    public float speed = 3.0f;
    public float rotationSpeed = 300.0f;
    public float translation;
    public float rotation;
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        //speed = new Vector3(0, 0, 0.1f);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        translation = Input.GetAxis("Vertical") * speed;
        rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        /*
        if (Input.GetKey("space"))
        {
            print("space key was pressed");
            Vector3 newPos = (transform.forward * speed * Time.deltaTime);
            rb.MovePosition( transform.position + newPos);
        }*/
        // Make it move 10 meters per second instead of 10 meters per frame...
        Vector3 newPos = (transform.forward * speed * Time.deltaTime * translation);
        rb.MovePosition(transform.position + newPos);

        //translation *= Time.deltaTime;
        //rotation *= Time.deltaTime;

        // Move translation along the object's z-axis


        // Rotate around our y-axis



        Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);

        // Apply this rotation to the rigidbody's rotation.
        rb.MoveRotation(rb.rotation * turnRotation);

    }
}
