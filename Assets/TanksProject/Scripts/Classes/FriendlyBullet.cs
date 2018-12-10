using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Bullet;
using _Tank;
public class FriendlyBullet : Bullet
{
    public override void OnCollisionEnter(Collision collision)
    {
        /* creo que no haria falta comprobar el tag */

            if (!(collision.collider.tag == "Player" || collision.collider.name == "Floor"))
            {
                print(collision.collider.name);
                if (collision.collider.tag == "Enemy")
                    collision.collider.GetComponent<Tank>().TakeDamage(damage);
                Destroy(gameObject);
            }

        
    }
}