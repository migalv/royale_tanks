using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using _Turret;
using _Bullet;
namespace _Tank
{
    abstract public class Tank : MonoBehaviour
    {
        //Vida del tanque
        public int hp = 1;

        //Velocidad del tanque
        public float speed;

        //Velocidad de la bala
        public float BulletSpeed = 15f;

        //Armadura del tanque
        public int armor;

        //Inventario del tanque(perks)
        public List<Perk> inventory = new List<Perk>();

        //Torreta del tanque
        public Turret turret;

        //ID del tanque
        public int id;

        //efecto de explosión del tanque
        public ParticleSystem explosion;

        //Proyectil que el tanque dispara
        public Bullet bullet;

        // Objeto donde desde donde se generan las balas
        public GameObject Cannon;

        public void DestroyTank() { 

            //Activamos las particulas para el efecto de explosión y luego desactivamos el tanque
            ParticleSystem ps = Instantiate(explosion, transform.position, transform.rotation);
            ps.gameObject.SetActive(true);
            ps.Play();
            gameObject.SetActive(false);
        }

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
