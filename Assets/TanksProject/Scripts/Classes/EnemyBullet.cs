using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Bullet;
using _Tank;
public class EnemyBullet : Bullet {


    public int dmg = 1;

    public override void OnCollisionEnter(Collision collision)
    {

        print("enemy bullet" + collision.collider.name);
        if (!(collision.collider.tag == "Enemy" || collision.collider.name == "Floor"))
        {
            print(collision.collider.name);
            if (collision.collider.tag == "Player")
                collision.collider.GetComponent<Tank>().TakeDamage(dmg);
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
