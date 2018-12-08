using UnityEngine;
using System;
using _Turret;

namespace _Bullet
{
    public abstract class Bullet : MonoBehaviour
    {
        /*
        // Constant that represents the base damage of any bullet
        public static const short BASE_DAMAGE = 20;
        // Constant that represents the base range of any bullet
        public static const int BASE_RANGE = 5;
        */
        // Daño: Determina la cantidad de puntos de vida (hp) que se le quita al objeto impactado con la bala
        public short damage = 1;
        // Rango: Rango máximo al que puede llegar la bala (repesentado en unidades de Unity). Una vez alcanzado se autodestruye.
        public int range = 1;

        // Torreta: Especifica la torreta en concreto que esta utilizando esta bala
        public Turret turret;

        // Particula: Especifica las particulas de la bala
        // private Particle particle;
        // Especifica como se ve la bala en el juego
        //private Sprite sprite;
        /*
        public Bullet(short damage = Bullet.BASE_DAMAGE, int range = Bullet.BASE_RANGE)
        {
            this.damage = damage;
            this.range = range;
            //this.particle = particle;
            //this.sprite = sprite;
        }
        */
        /*
        public setTurret(Turret turret)
        {
            this.turret = turret;
        }
        */
        public override String ToString()
        {
            return GetType().Name + ": {\n" +
                        "  damage --> " + damage + "\n" +
                        "  range --> " + range + "\n" +
                        //"  particle --> " + this.particle.toString() + "\n" +
                        //"  sprite (path) --> " + this.sprite.path + "\n" +
                    "}\n";
        }
        public abstract void OnCollisionEnter(Collision collision);
    }

}
