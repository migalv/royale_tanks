using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "EnemyBullet")
        {

            if (!(collision.collider.tag == "Enemy" || collision.collider.name == "Floor"))
            {
                
                print(collision.collider.name);
                Destroy(gameObject);
            }
         
        }
        else if (gameObject.tag == "FriendlyBullet")
        {
            if (!(collision.collider.tag == "Player" || collision.collider.name == "Floor"))
            {
                print(collision.collider.name);
                Destroy(gameObject);
            }
        }
    }
}
