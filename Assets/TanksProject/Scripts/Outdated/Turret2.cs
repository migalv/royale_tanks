using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret2 : MonoBehaviour
{

    public Vector3 mouse_pos;
    // public Transform target; //Assign to the object you want to rotate
    public Vector3 object_pos;
    public float angle;
    public float contiguo;
    public float opuesto;
    public float speed = 15f;
    //public Rigidbody rb;
    public Camera cam;
    public GameObject bullet;
    public float TurretAngle;
    public GameObject spawner;
    public float fireRate = 0.5f;
    int floorMask;
    //float camRayLength = 100f;
    public bool allowFire = true;
    // Use this for initialization
    void Awake()
    {
        //rb = gameObject.GetComponent<Rigidbody>();
        floorMask = LayerMask.GetMask("Floor");
        //print(floorMask);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LookAtMouse();
        if (Input.GetKey("space") && allowFire)
        {
            StartCoroutine("Shoot");




        }
    }


    void LookAtMouse()
    {
        // Cogemos posición del ratón
        // mouse_pos = Input.mousePosition;

        // Cogemos posición del objeto que va a mirar al ratón
        /*
        object_pos = cam.WorldToScreenPoint(transform.position);

        // Cogemos la diferencia de ambas posiciones, x e y, para calcular la tangente

        mouse_pos.x = mouse_pos.x - object_pos.x;
        contiguo = mouse_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        opuesto = mouse_pos.y;

        // Con la tangente, sacamos el ángulo correspondiente, y se pasa a grados

        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        TurretAngle = angle * -1 + 90;
        // Se rota el objeto según el ángulo obtenido

        transform.rotation = Quaternion.Euler(new Vector3(0, TurretAngle, 0));*/

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


    IEnumerator Shoot()
    {
        GameObject newBullet = Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);
        //newBullet.transform.LookAt(spawner.transform.position);
        //newBullet.transform.Translate(spawner.transform.position * 1.5f * Time.deltaTime);
        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * speed;
        print(newBullet.GetComponent<Rigidbody>().velocity);
        Destroy(newBullet, 2.0f);
        allowFire = false;
        yield return new WaitForSeconds(fireRate);
        allowFire = true;

        // Create the Bullet from the Bullet Prefab
        /* var bullet = (GameObject)Instantiate(
             bulletPrefab,
             bulletSpawn.position,
             bulletSpawn.rotation);

         // Add velocity to the bullet
         bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

         // Destroy the bullet after 2 seconds
         Destroy(bullet, 2.0f);*/
    }





}


