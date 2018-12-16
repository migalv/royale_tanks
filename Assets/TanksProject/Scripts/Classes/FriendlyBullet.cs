using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Bullet;
using _Tank;
public class FriendlyBullet : Bullet
{
    public GameObject impactVFXPrefab;

    private void Start()
    {
        Destroy(gameObject, 2f);
    }
    public override void OnCollisionEnter(Collision collision)
    {


        if (!(collision.collider.tag == "Player" || collision.collider.name == "Floor"))
        {
            if (impactVFXPrefab != null)
            {
                ContactPoint contact = collision.contacts[0];
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
                Vector3 pos = contact.point;
                var impactVFX = Instantiate(impactVFXPrefab, pos, rot);
                Destroy(impactVFX, 2f);
            }
            if (collision.collider.tag == "Enemy")
                collision.collider.GetComponent<Tank>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}