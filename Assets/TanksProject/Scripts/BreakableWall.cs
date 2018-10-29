using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour {

    public ParticleSystem ps_break;


    private void OnCollisionEnter(Collision collision)
    {
        ps_break.transform.position = transform.position;
        ps_break.gameObject.SetActive(true);
        ps_break.Play();

        gameObject.SetActive(false);

    }

}
