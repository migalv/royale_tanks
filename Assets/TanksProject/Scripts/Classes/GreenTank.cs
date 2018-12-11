using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Bullet;
public class GreenTank : EnemyTank {

    public override IEnumerator Shoot()
    {
        int nbullets;
        float randomBulletRotation;

        //Instanciamos una nueva bala, y le damos una velocidad, esperamos 
        //un tiempo y después levantamos la flag para volver a disparar si es necesario

        allowFire = false;
        //Creamos varias balas que iran a una dirección random entre -30º y 30º
        nbullets = Random.Range(3, 6);

        for (var i = 0; i < nbullets; i++)
        {
            randomBulletRotation = Random.Range(-30f, 30f);
            Bullet newBullet = Instantiate(bullet, Cannon.transform.position, Cannon.transform.rotation);
            newBullet.transform.Rotate(0, randomBulletRotation, 0);
            newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * BulletSpeed * Random.Range(3f, 7f);
        }
        yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));
        allowFire = true;

    }
}
