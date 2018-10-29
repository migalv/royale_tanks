using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int health;
    public ParticleSystem explosion;
    // Use this for initialization
    void Start () {
        explosion.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            ParticleSystem ps = Instantiate(explosion, transform.position, transform.rotation);

            ps.gameObject.SetActive(true);

            // Play the particle system of the tank exploding.
            ps.Play();
            gameObject.SetActive(false);
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if ((gameObject.tag == "Breakable" || gameObject.tag == "Player" )&& collision.collider.tag == "EnemyBullet")
            health--;
        else if ((gameObject.tag == "Breakable" || gameObject.tag == "Enemy") && collision.collider.tag == "FriendlyBullet")
            health--;


    }
}
