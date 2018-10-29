using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
                                    /* PlayerHealth playerHealth;      // Reference to the player's health.
                                     EnemyHealth enemyHealth;        // Reference to this enemy's health.*/
    NavMeshAgent nav;               // Reference to the nav mesh agent.
    //NavMeshHit hit;
    public GameObject spawner;
    public GameObject bullet;
    public float speed = 15f;
    public bool allowFire = true;
    public RaycastHit hit;
    public LayerMask lm;
    public float minFireRate = 0.5f;
    public float maxFireRate = 2f;
    public float limitDistance = 10f;

    private Vector3 visionOffset = new Vector3(0.03269768f, 0.487f, 0.9388409f);
    /* Variables para los tipos de enemigos */
    int nbullets;
    float randomBulletRotation;
    public bool multipleShot = false;

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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "bullet")
        {

            // Destroy(collision.gameObject);
            Destroy(gameObject);


        }



    }

    void Update()
    {

        /* dirección a la que mandar el raycast */
        var rayDirection = player.position - (spawner.transform.position );

        /* Si encuentra al player en el raycast... */
        if (Physics.Raycast((spawner.transform.position ), rayDirection, out hit, Mathf.Infinity, lm) && hit.collider.name == "RedTank")
        {
            /* La AI puede ver al player */
            print(hit.collider.name);
            Debug.DrawRay(hit.point, (spawner.transform.position + visionOffset), Color.red);

            /*Si la AI puede disparar... */
            if (allowFire)
                /* Dispara */
                StartCoroutine("AIShoot");

            /* Distancia entre el player y la AI */

            var distance = Vector3.Distance(player.position, transform.position);
            /*Si la distancia es mayor a la límite...*/
            if (distance >= limitDistance)
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


    IEnumerator AIShoot()
    {

        allowFire = false;
        
        //newBullet.transform.LookAt(spawner.transform.position);
        //newBullet.transform.Translate(spawner.transform.position * 1.5f * Time.deltaTime);
        //Physics.IgnoreCollision(newBullet.GetComponent<Collider>(), GetComponent<Collider>());

        if (multipleShot)
        {
            nbullets = Random.Range(3, 6);

            for(var i = 0; i < nbullets; i++)
            {
                randomBulletRotation = Random.Range(-30f, 30f);
                GameObject newBullet = Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);
                newBullet.transform.Rotate(0, randomBulletRotation, 0);
                newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * speed * Random.Range(3f,7f);
            }
        }

        else
        {
            GameObject newBullet = Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * speed;
            Destroy(newBullet, 5.0f);
        }

        //newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * speed;
 
        yield return new WaitForSeconds(Random.Range(minFireRate, maxFireRate));
        allowFire = true;
    }
}