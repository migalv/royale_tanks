using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownBullet : MonoBehaviour {

    public Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("slowDown");
        print(rb.velocity);
        if (Mathf.Abs(rb.velocity.x) < 1 || Mathf.Abs(rb.velocity.z) < 1)
            Destroy(gameObject);
	}

    IEnumerator slowDown()
    {

        yield return new WaitForSeconds(0.1f);

        rb.drag += Random.Range(3f, 5f);


    }

}
