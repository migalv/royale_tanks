using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using _Tank;

abstract public class EnemyTank : Tank
{
    // Transform del player, para saber su posición
    Transform player;

    // Reference to the nav mesh agent.
    NavMeshAgent nav;   

    //Flag para saber si el tanque puede disparar o no
    public bool allowFire = true;

    //Variable en la que se guarda la información del raycast cuando colisiona
    public RaycastHit hit;

    //Layermask para permitir al raycast ignorar algunos objetos según su capa
    public LayerMask lm;

    //Variables para controlar la cadencia de los tanques
    public float minFireRate = 0.5f;
    public float maxFireRate = 2f;

    //Variable para controlar la distancia a la que el tanque se para si se acerca demasiado a su objetivo
    public float limitDistance = 10f;

    //Variable para que el raycast tenga su origen centrado respecto del cañon
    private Vector3 visionOffset = new Vector3(0.03269768f, 0.487f, 0.9388409f);

    void Awake()
    {
        // Buscamos el objeto player y nos quedamos con la referencia de su transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Activamos el nav para que empiece a buscar al player
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

    public void Update()
    {
        //Para saber si el tanque se tiene que destruir
        if (hp <= 0)
            DestroyTank();
        
        /* dirección a la que mandar el raycast */
        var rayDirection = player.position - (Cannon.transform.position);

        /* Si encuentra al player en el raycast... */
        if (Physics.Raycast((Cannon.transform.position), rayDirection, out hit, Mathf.Infinity, lm) && hit.collider.name == "RedTank")
        {
            /* La AI puede ver al player */
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
    }
}
