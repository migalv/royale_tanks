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
        public bool allowFire = true;

        // Cadencia de la torreta (Viene determinada por cuantas balas se disparan por segundo)
        public float fireRate = 0.5f;
        // Capacidad del cargador: Define cuantas balas hay en un cargador
        public short clipSize = 1;
        // Capacidad total de la torreta: Define cuantos cargadores te quedan
        public float capacity = 1;

        public float rotationSpeed = 300.0f;

        Rigidbody rb;
        
        private void Awake()
        {

            speed = 3f;
            rb = gameObject.GetComponent<Rigidbody>();
            //speed = new Vector3(0, 0, 0.1f);
        }
        private void Update()
        {
            if(hp <= 0)
                DestroyTank();

            if (Input.GetMouseButton(0) && allowFire)
                StartCoroutine("Shoot");
        }
        private void FixedUpdate()
        {
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
            Bullet newBullet = Instantiate(bullet, Cannon.transform.position, Cannon.transform.rotation);

            newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * BulletSpeed;
            print(newBullet.GetComponent<Rigidbody>().velocity);
            Destroy(newBullet, 2.0f);
            allowFire = false;
            yield return new WaitForSeconds(fireRate);
            allowFire = true;
        }
        public override void TakeDamage(int dmg)
        {
            hp -= dmg;
        }
    }
}
