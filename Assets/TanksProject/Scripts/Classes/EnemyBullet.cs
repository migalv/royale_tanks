using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Bullet;
using _Tank;
public class EnemyBullet : Bullet {


    public override void OnCollisionEnter(Collision collision)
    {
        if (!(collision.collider.tag == "Enemy" || collision.collider.name == "Floor"))
        {

            if (collision.collider.tag == "Player")
                collision.collider.GetComponent<Tank>().TakeDamage(damage);
            Destroy(gameObject);
        }

        /* creo que no haria falta comprobar el tag */
        /*if (gameObject.tag == "EnemyBullet")
        {

            if (!(collision.collider.tag == "Enemy" || collision.collider.name == "Floor"))
            {

                print(collision.collider.name);
                Destroy(gameObject);
            }

        }  */      
    }
}
