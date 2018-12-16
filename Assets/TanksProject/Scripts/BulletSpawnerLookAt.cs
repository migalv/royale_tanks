using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawnerLookAt : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 point = new Vector3();
    Vector3 mousePos = new Vector2();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        mousePos = Input.mousePosition;
        mousePos += Camera.main.transform.forward * 10f;
        gameObject.transform.LookAt(Camera.main.ScreenToWorldPoint(mousePos));  
    }
}
