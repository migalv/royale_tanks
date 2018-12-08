using System.Collections;
using System;
using UnityEngine;
using _Tank;
using _Bullet;

namespace _Turret
{
    abstract public class Turret : MonoBehaviour
    {
        /*
        // Constant that represents the base cadence of any turret
        public static const short BASE_CADENCE = 1;
        // Constant that represents the base clip size of any turret
        public static const short BASE_CLIPSIZE = 5;
        // Constant that represents the base ammunition capacity of any turret (infinty)
        public static const float BASE_CAPACITY = 1 / 0.0f;
        */
        // Tanque al cual pertenece esta torreta.
        public Tank tank;

        // Cadencia de la torreta (Viene determinada por cuantas balas se disparan por segundo)
        public short cadence = 1;
        // Capacidad del cargador: Define cuantas balas hay en un cargador
        public short clipSize = 1;
        // Capacidad total de la torreta: Define cuantos cargadores te quedan
        public float capacity = 1;
        // Define el tipo de bala que utiliza la torreta
        public Bullet bullet;
        /*
        // Constructor, por defecto los valores son los base.
        public Turret(short cadence = Bullet.BASE_CADENCE, short clipSize = Bullet.BASE_CADENCE, float capacity = Bullet.BASE_CADENCE, Bullet bullet, Tank tank)
        {
            this.cadence = cadence;
            this.clipSize = clipSize;
            this.capacity = capacity;
            this.bullet = bullet;
            this.tank = tank;
        }
        */
        public void Update()
        {
            Look();
        }
        public abstract void Look();
        public override String ToString()
        {
            return this.GetType().Name + ": {\n" +
                        "  cadence --> " + cadence + "\n" +
                        "  clip size --> " + clipSize + "\n" +
                        "  capacity --> " + capacity + "\n" +
                        "  bullet type --> " + bullet.ToString() + "\n" +
                    "}\n";
        }
    }
}
