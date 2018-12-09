using _PlayerTank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _GameOver;

public class LevelManager : MonoBehaviour {

    public List<Level> levels;
    public int levelIndex = 0;

    public static bool LoadNextLevel = false;
    public static int numberOfEntities = -1;
    public GameObject GreenTank;
    public GameObject BlueTank;
    public GameObject PinkTank;
    public GameObject player;
    public GameObject portal;
    private List<GameObject> spawnpoints;
    
    private List<GameObject> tankTypes;
    public List<GameObject> currentEntities;
    public List<GameObject> spawnpoints_aux;
    public ParticleSystem ps_spawn;
    public bool hasStarted = false;
    public Vector3 initial_player_pos = new Vector3(11, 2.5f, 17);
    public bool LevelPassed = false;

    // Use this for initialization
    void Start () {
        tankTypes = new List<GameObject>
        {
            GreenTank,
            BlueTank,
            PinkTank
        };
        spawnpoints_aux = new List<GameObject>();
        currentEntities = new List<GameObject>();
        //StartCoroutine("SpawnPlayer");
        StartCoroutine("SpawnEnemiesAndPlayer");
	}
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<PlayerTank>().hp <= 0)
        {
            GameOver.ShowGameOver(GameOverCondition.LOST);
        }
      
        if (hasStarted) { 
		    for (var i = 0; i < currentEntities.Count; i++)
            {
                if (!currentEntities[i].activeSelf)
                {
                    currentEntities.RemoveAt(i);
                    numberOfEntities--;
                }      
            }
            //print(currentEntities.Count);
            if (numberOfEntities == 0)
            {
                LoadNextLevel = true;
                numberOfEntities = -1;
                levelIndex = Random.Range(0, 2);
                StartCoroutine("Reset");         
                ParticleSystem player_ps = Instantiate(ps_spawn, player.transform.position, player.transform.rotation);
                player_ps.gameObject.SetActive(true);
                player_ps.Play();
                player.SetActive(false);
                StartCoroutine("SpawnEnemiesAndPlayer");
            }
        }
    }
  
    IEnumerator Reset()
    {
        yield return new WaitForSeconds(BlockAnimation.minWaitTime);
        LoadNextLevel = false;
        
    }
    IEnumerator SpawnEnemiesAndPlayer()
    {
        Level level = Instantiate(levels[levelIndex],new Vector3(0,50,0), Quaternion.identity);
        //level.setActive(true);
        /*Esperamos a que el mapa esté colocado */
        yield return new WaitForSeconds(6);

        ParticleSystem player_ps = Instantiate(ps_spawn, initial_player_pos, player.transform.rotation);
        player_ps.gameObject.SetActive(true);
        player_ps.Play();
        yield return new WaitForSeconds(0.5f);
        player_ps.gameObject.SetActive(false);

        player.SetActive(true);
        player.GetComponent<PlayerTank>().allowFire = true;
        player.transform.position = initial_player_pos;

        /*Damos unos segundos para que el player pueda moverse y ver el mapa */
        yield return new WaitForSeconds(4);

        /* Decidimos de forma random cuantos enemigos habra */
        int enemiesLeftToSpawn = Random.Range(2, 4);

        /*Nos lo guardamos en una variable para ver si llega a 0 para pasar de nivel */
        numberOfEntities = enemiesLeftToSpawn;

        /*Bucle para decidir que spawns utilizar */

        spawnpoints_aux = level.spawnpoints;

        /*mientras haya enemigos que spawnear*/
   
        while (enemiesLeftToSpawn > 0) { 
            /*Recorremos cada spawn*/
            foreach (GameObject spawn in spawnpoints_aux)
            {
                if (enemiesLeftToSpawn <= 0)
                    break;
                /*Número random entre 0 y 1 para decidir si el spawn es utilizado*/
                float flag = Random.Range(0f, 1f);
                /*50% de prob */
                if (flag <= 0.5)
                {
                    /*Se elige un tipo de enemigo */
                    int tankType = Random.Range(0, 3);
                   /*Particlesystem para la animación del spawn*/
                    ParticleSystem ps = Instantiate(ps_spawn, spawn.transform.position, spawn.transform.rotation);
                    ps.gameObject.SetActive(true);
                    ps.Play();
                    yield return new WaitForSeconds(0.5f);
                    ps.gameObject.SetActive(false);
                    /*Se spawnea el enemigo*/
                    GameObject go = Instantiate(tankTypes[tankType], spawn.transform.position, spawn.transform.rotation);
                    currentEntities.Add(go);
                    /*Hay un enemigo menos que spawnear*/
                    enemiesLeftToSpawn--;
                    /*El spawn ha sido usado asi que se quita de la lista de posibles*/
                    //spawnpoints_aux.Remove(spawn);
                    /*Hay que buscar una manera de eliminar el spawn usado sin afectar a spawnpointsaux*/

                }
            }
        }
        hasStarted = true;
    }
}
