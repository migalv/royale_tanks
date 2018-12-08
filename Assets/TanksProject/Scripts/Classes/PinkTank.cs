using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkTank : EnemyTank
{
    public float BulletSpeed;


    public override IEnumerator Shoot()
    {
        allowFire = false;
        GameObject newBullet = Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * BulletSpeed;
        Destroy(newBullet, 5.0f);
        yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));
        allowFire = true;

    }
}
