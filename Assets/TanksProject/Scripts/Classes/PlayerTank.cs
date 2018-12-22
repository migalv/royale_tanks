using System.Collections;
using UnityEngine;
using _Tank;
using _Bullet;
namespace _PlayerTank
{
    public class PlayerTank : Tank
    {
        /*
        // Constant that represents the base cadence of any turret
        public static const short BASE_CADENCE = 1;
        // Constant that represents the base clip size of any turret
        public static const short BASE_CLIPSIZE = 5;
        // Constant that represents the base ammunition capacity of any turret (infinty)
        public static const float BASE_CAPACITY = 1 / 0.0f;
        */

        //Renderer del player, para el efecto de recibir daño
        public Renderer rend;

        //Tiempo de parpadeo del player cuando recibe daño
        public float rendTime = 0.05f;
        
        //Flag para saber si se puede disparar
        public bool allowFire = true;

        //Flag para saber si el player puede recibir daño o no
        public bool invulnerability = false;

        // Tiempo que pasa hasta que el jugador puede volver a sufrir daño después de un impacto
        public float recoverTimeAfterHit = 1.6f;

        // Cadencia de la torreta (Viene determinada por cuantas balas se disparan por segundo)
        public float fireRate = 0.5f;
        
        // Capacidad del cargador: Define cuantas balas hay en un cargador
        public short clipSize = 1;
        
        // Capacidad total de la torreta: Define cuantos cargadores te quedan
        public float capacity = 1;

        public float rotationSpeed = 300.0f;

        public GameObject muzzleVFXPrefab;
        
        //Rigidbody para el movimiento del tanque
        Rigidbody rb;

        public GameObject lm; 

        private void Awake()
        {
            //Asignamos una velocidad a nuestro tanque y cogemos su rigidbody
            hp = 3;
            rend = GetComponent<Renderer>();
            speed = 3f;
            rb = gameObject.GetComponent<Rigidbody>();
            //GameObject lm = GameObject.Find("LevelManager");
            //speed = new Vector3(0, 0, 0.1f);
        }
        private void Update()
        {
            //Se comprueba que el tanque siga vivo y si se quiere disparar
            if(hp <= 0)
                DestroyTank();

            if (Input.GetMouseButton(0) && allowFire)
                StartCoroutine("Shoot");
        }
        private void FixedUpdate()
        {
            //Se comprueba el input de los botones de movimiento para ver si hay que mover el tanque
            float translation;
            float rotation;

            translation = Input.GetAxis("Vertical") * speed;
            rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;

            // Make it move 10 meters per second instead of 10 meters per frame...
            Vector3 newPos = (transform.forward * speed * Time.deltaTime * translation);
            rb.MovePosition(transform.position + newPos);

            // Rotate around our y-axis
            Quaternion turnRotation = Quaternion.Euler(0f, rotation, 0f);

            // Apply this rotation to the rigidbody's rotation.
            rb.MoveRotation(rb.rotation * turnRotation);

        }
        public override IEnumerator Shoot()
        {
            //Instanciamos una nueva bala, y le damos una velocidad, esperamos 
            //un tiempo y después levantamos la flag para volver a disparar si es necesario

            if (muzzleVFXPrefab != null)
            {
                var muzzleVFX = Instantiate(muzzleVFXPrefab, Cannon.transform.position, Cannon.transform.rotation);
                Destroy(muzzleVFX, 2f);
            }

            Bullet newBullet = Instantiate(bullet, Cannon.transform.position, Cannon.transform.rotation);

            newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * BulletSpeed;

            Destroy(newBullet, 2.0f);
            allowFire = false;
            yield return new WaitForSeconds(fireRate);
            allowFire = true;
        }

        public override void TakeDamage(int dmg)
        {
            if (!invulnerability)
            {
                if (hp - dmg < 0)
                    hp = 0;
                else
                {
                    hp -= dmg;
                    StartCoroutine("RecoverAfterHit");
                }
            }
        }

        public IEnumerator RecoverAfterHit()
        {

            invulnerability = true;
            lm.GetComponent<CameraShake>().ShakeIt();
            GameObject renderers = gameObject.transform.GetChild(0).gameObject;
            for (int i = 0; i <  8; i++)
            {
                
                if (renderers.activeSelf)
                    renderers.SetActive(false);
                else renderers.SetActive(true);
                yield return new WaitForSeconds(0.1f);

            }
            //yield return new WaitForSeconds(recoverTimeAfterHit);
            invulnerability = false;
        }
    }
}
