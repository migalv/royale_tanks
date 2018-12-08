using System.Collections;
using UnityEngine;
using _Tank;
using _Bullet;
namespace _PlayerTank
{
    public class PlayerTank : Tank
    {
        public Bullet bullet;
        public GameObject spawner;
        public float fireRate = 0.5f;
        public bool allowFire = true;

        Rigidbody rb;
        
        public float rotationSpeed = 300.0f;
        public float translation;
        public float rotation;
        public float BulletSpeed = 15f;
        private void Start()
        {
            hp = 3;
            speed = 3f;
            rb = gameObject.GetComponent<Rigidbody>();
            //speed = new Vector3(0, 0, 0.1f);
        }
        private void Update()
        {
            CheckIfDead();
            if (Input.GetKey("space") && allowFire)
                StartCoroutine("Shoot");

        }
        private void FixedUpdate()
        {

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
            Bullet newBullet = Instantiate(bullet, spawner.transform.position, spawner.transform.rotation);

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
