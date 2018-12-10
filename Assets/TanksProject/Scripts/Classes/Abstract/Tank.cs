using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using _Turret;
namespace _Tank
{
    abstract public class Tank : MonoBehaviour
    {
        public int hp = 1;
        public float speed;
        public float BulletSpeed = 15f;
        public int armor;
        public List<Perk> inventory = new List<Perk>();
        public Turret turret;
        public int id;
        public ParticleSystem explosion;
        public Bullet bullet;

        // Objeto donde desde donde se generan las balas
        public GameObject Cannon;


        // Constant that represents the base hp of any tank
        //public static const short BASE_HP = 100;
        // Constant that represents the base armor of any tank
        //public static const short BASE_ARMOR = 100;
        // Constant that represents the base armor of any tank
        //public static const short BASE_SPEED = 100;

        // Attribute that represents the actual health of the Tank
        //public short hp = 1;
        // Attribute that represents the maximum armor of the Tank
        //public short armor = 1;
        // Attribute that represents the maximum speed of the Tank
        //public short speed = 1;
        // Atribute that represents the turret of the tank
        //public Turret turret;
        // A list of Perks that the player currently has on him.
        /*  
	    public Tank(short hp, short armor, short speed, Turret t)
	    {
            this.hp = hp;
            this.armor = armor;
            this.speed = speed;
            this.turret = t;
            this.inventory = new List<Perk>();
        }
        */
        /*public void Start()
        {
            //explosion.gameObject.SetActive(false);
        }*/
        // Update is called once per frame

        public void DestroyTank() { 
            ParticleSystem ps = Instantiate(explosion, transform.position, transform.rotation);

            ps.gameObject.SetActive(true);

            // Play the particle system of the tank exploding.
            ps.Play();
            gameObject.SetActive(false);
        }
        //public abstract void OnCollisionEnter(Collision collision);

        public abstract IEnumerator Shoot();
        public abstract void TakeDamage(int dmg);
        public override string ToString()
        {
            return this.GetType().Name + ": " + this.id + " {\n" +
                        "  hp --> " + this.hp + "\n" +
                        "  armor --> " + this.armor + "\n" +
                        "  speed --> " + this.speed + "\n" +
                        "  turret --> " + this.turret.ToString() + "\n" +
                        "  inventory --> " + this.inventory.ToString() + "\n" +
                    "}\n";
        }
        
    }
}
