using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Turret;
public class PlayerTurret : Turret {

    public Vector3 mouse_pos;
    // public Transform target; //Assign to the object you want to rotate
    public Vector3 object_pos;
    public float angle;
    public float contiguo;
    public float opuesto;
    public float speed = 15f;
    public Rigidbody rb;
    public Camera cam;
    //public GameObject bullet;
    public float TurretAngle;
    //public GameObject spawner;
    //public float fireRate = 0.5f;
    int floorMask;
    float camRayLength = 100f;
    //public bool allowFire = true;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
        //print(floorMask);

    }

    public override void Look()
    {
        // Create a ray from the mouse cursor on screen in the direction of the camera.
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Create a RaycastHit variable to store information about what was hit by the ray.
        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        //Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition), Vector3.forward, Color.green);

        if (Physics.Raycast(camRay, out floorHit, floorMask))
        {
            print("raycast");
            // Create a vector from the player to the point on the floor the raycast from the mouse hit.
            Vector3 playerToMouse = floorHit.point - transform.position;

            // Ensure the vector is entirely along the floor plane.
            playerToMouse.y = 0f;

            // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            // Set the player's rotation to this new rotation.
            transform.rotation = newRotation;
            //rb.MoveRotation(newRotation);

        }
    }
}
