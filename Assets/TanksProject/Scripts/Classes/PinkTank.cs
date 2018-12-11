using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Bullet;
public class PinkTank : EnemyTank
{
    public override IEnumerator Shoot()
    {
        //Instanciamos una nueva bala, y le damos una velocidad, esperamos 
        //un tiempo y después levantamos la flag para volver a disparar si es necesario
        allowFire = false;
        Bullet newBullet = Instantiate(bullet, Cannon.transform.position, Cannon.transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * BulletSpeed;
        Destroy(newBullet, 5.0f);
        yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));
        allowFire = true;

    }
}
