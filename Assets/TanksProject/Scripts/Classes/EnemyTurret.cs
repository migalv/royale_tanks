using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _Turret;
public class EnemyTurret : Turret {

    Transform player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // print(GameObject.FindGameObjectWithTag("Player").name);
    }

    public override void Look()
    {
        Vector3 rotation = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(rotation);
    }
}
