using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using _Tank;

abstract public class EnemyTank : Tank
{
    // Reference to the player's position.
    Transform player;

    // Reference to the nav mesh agent.
    NavMeshAgent nav;   
    
    //NavMeshHit hit;

    //public float speed = 15f;
    public bool allowFire = true;
    public RaycastHit hit;
    public LayerMask lm;
    public float minFireRate = 0.5f;
    public float maxFireRate = 2f;
    public float limitDistance = 10f;

    private Vector3 visionOffset = new Vector3(0.03269768f, 0.487f, 0.9388409f);
    /* Variables para los tipos de enemigos */
    //int nbullets;
    //float randomBulletRotation;
    //public bool multipleShot = false;

    void Awake()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        /* playerHealth = player.GetComponent<PlayerHealth>();
         enemyHealth = GetComponent<EnemyHealth>();*/
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
        nav.SetDestination(player.position);
    }


    /* para debuguear lo que la AI esta viendo */
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 1);
        Gizmos.DrawSphere(hit.point, 1);
    }

    /*
    public override void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {
            // Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }*/

    public void Update()
    {
        if (hp <= 0)
            DestroyTank();
        
        /* dirección a la que mandar el raycast */
        var rayDirection = player.position - (Cannon.transform.position);

        /* Si encuentra al player en el raycast... */
        if (Physics.Raycast((Cannon.transform.position), rayDirection, out hit, Mathf.Infinity, lm) && hit.collider.name == "RedTank")
        {
            /* La AI puede ver al player */
            print("collider : " + hit.collider.name);
            Debug.DrawRay(hit.point, (Cannon.transform.position + visionOffset), Color.red);

            /*Si la AI puede disparar... */
            if (allowFire)
                /* Dispara */
                StartCoroutine("Shoot");

            /* Distancia entre el player y la AI */

            var distance = Vector3.Distance(player.position, transform.position);
            /*Si la distancia es mayor a la límite...*/
            if (distance >= limitDistance && gameObject.activeSelf)
            {
                /*La AI se sigue moviendo hacia el player */
                nav.enabled = true;
                nav.SetDestination(player.position);
            }

            else
            {
                /*La AI se para */
                nav.enabled = false;
            }
        }
        else
        {
            /*Si no puede ver al player, la AI se sigue moviendo */
            nav.enabled = true;
            nav.SetDestination(player.position);
        }
        /*
        if (!nav.Raycast(player.position, out hit) && allowFire)
        {
            StartCoroutine("AIShoot");
           


            // Target is "visible" from our position.
        }*/


        //}
        // Otherwise...
        /*else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;
        }*/
    }
    public override void TakeDamage(int dmg)
    {
        if (hp - dmg < 0)
            hp = 0;
        else hp -= dmg;

        //throw new System.NotImplementedException();
    }

}
