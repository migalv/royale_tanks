using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketVFX : MonoBehaviour
{
    public GameObject impactVFXPrefab;
    public GameObject muzzleVFXPrefab;

    void Start()
    {
        if(muzzleVFXPrefab != null)
        {
            var muzzleVFX = Instantiate(muzzleVFXPrefab, transform.position, Quaternion.identity);
            muzzleVFX.transform.forward = gameObject.transform.forward;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (impactVFXPrefab != null) { 
            ContactPoint contact = collision.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 pos = contact.point;
            var impactVFX = Instantiate(impactVFXPrefab, pos, rot);
        }
    }
}
