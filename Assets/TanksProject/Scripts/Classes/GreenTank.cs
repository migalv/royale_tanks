using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTank : EnemyTank {
    public float BulletSpeed;
    // Use this for initialization

    // Update is called once per frame

    public override IEnumerator Shoot()
    {
        int nbullets;
        float randomBulletRotation;
        
        allowFire = false;
        nbullets = Random.Range(3, 6);

        for (var i = 0; i < nbullets; i++)
        {
            randomBulletRotation = Random.Range(-30f, 30f);
            GameObject newBullet = Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);
            newBullet.transform.Rotate(0, randomBulletRotation, 0);
            newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * BulletSpeed * Random.Range(3f, 7f);
        }
        yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));
        allowFire = true;

    }
}
