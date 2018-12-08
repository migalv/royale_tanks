using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using _Tank;
public class UIHealth : MonoBehaviour {

    public Image[] hearts;
    public GameObject player;
    public int health;
    public Sprite fullheart;
    public Sprite emptyheart;
    /*Numero máximo de vidas que se veran en display */
    //public int maxHealthDisplay = 3;
	// Use this for initialization
	void Start () {
        hearts = GetComponentsInChildren<Image>();
        /*for (int i = 0; i < hearts.Length; ++i)
        {
            hearts[i].
        }*/
        health = player.GetComponent<Tank>().hp;
    }
	
	// Update is called once per frame
	void Update () {
        /*if(health > player.GetComponent<Health>().health)
        {
            health--;
        }*/


        health = player.GetComponent<Tank>().hp;
        //print(hearts.Length);

        /* empieza en 1 porque por algun motivo el 
         * metodo getchildren incluye al padre en el array en la posicion 0 */

        for (var i = 1; i <= health; i++)
        {
            //print(hearts[i].GetType());
            hearts[i].overrideSprite = fullheart;

        }
        for (var i = health + 1; i < hearts.Length; i++)
        {
            if(i != 0)
                hearts[i].overrideSprite = emptyheart;

        }

    }
}
