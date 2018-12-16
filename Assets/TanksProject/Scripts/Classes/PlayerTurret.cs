using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Turret;
public class PlayerTurret : Turret {

    public LayerMask floorMask;

    void Awake()
    {
        
        //floorMask = LayerMask.GetMask("Floor");
    }

    public override void Look()
    {
        
            // Create a ray from the mouse cursor on screen in the direction of the camera.
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Create a RaycastHit variable to store information about what was hit by the ray.
            RaycastHit floorHit;

            // Perform the raycast and if it hits something on the floor layer
            if (Physics.Raycast(camRay, out floorHit, floorMask))
            {

                // Create a vector from the player to the point on the floor the raycast from the mouse hit.
                Vector3 playerToMouse = floorHit.point - transform.position;

                // Ensure the vector is entirely along the floor plane.
                playerToMouse.y = 0f;

                // Create a quaternion (rotation) based on looking down the vector from the player to the mouse.
                Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

                // Set the player's rotation to this new rotation.
                transform.rotation = newRotation;


            }
        /*Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        RaycastHit rayLength;

        if(Physics.Raycast(camRay, out rayLength, floorMask))
        {
            Vector3 pointToLook = camRay.GetPoint(rayLength);
            Debug.DrawLine(camRay.origin, pointToLook, Color.blue);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
        
        */
    }

    
    }
