using System.Collections;
using System;
using UnityEngine;
using _Tank;
using _Bullet;

namespace _Turret
{
    abstract public class Turret : MonoBehaviour
    {

        public void Update()
        {
            Look();
        }
        public abstract void Look();
        public override String ToString()
        {
            return this.GetType().Name + ": {\n" +
                        //"  cadence --> " + cadence + "\n" +
                        //"  clip size --> " + clipSize + "\n" +
                        //"  capacity --> " + capacity + "\n" +
                        //"  bullet type --> " + bullet.ToString() + "\n" +
                    "}\n";
        }
    }
}
