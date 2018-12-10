using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTank : EnemyTank {

    public override IEnumerator Shoot()
    {
        int nbullets;
        float randomBulletRotation;
        
        allowFire = false;
        nbullets = Random.Range(3, 6);

        for (var i = 0; i < nbullets; i++)
        {
            randomBulletRotation = Random.Range(-30f, 30f);
            GameObject newBullet = Instantiate(bullet, Cannon.transform.position, Cannon.transform.rotation);
            newBullet.transform.Rotate(0, randomBulletRotation, 0);
            newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * BulletSpeed * Random.Range(3f, 7f);
        }
        yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));
        allowFire = true;

    }
}
