using _PlayerTank;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using _GameOver;
using _Config;

public class LevelManager : MonoBehaviour {

    /*Lista de niveles */
    public List<Level> levels;
    /*Indice del nivel actual */
    public int levelIndex;

    /* Variable para controlar el paso de un nivel a otro*/
    public static bool LoadNextLevel = false;
    
    /*Numero de entidades enemigas vivas en un nivel en un momento dado*/
    public static int numberOfEntities = -1;
    
    /*Tipos de enemigos que pueden spawnear*/
    public GameObject GreenTank;
    public GameObject BlueTank;
    public GameObject PinkTank;
    
    /*Objeto que hace referencia al jugador*/
    public GameObject player;
    //public GameObject portal;
    
        /*Lista de spawns de un nivel*/
    private List<GameObject> spawnpoints;

    /*Panel de GameOver (UI)*/
    public GameObject GameOverPanel;

    /*Lista con los tipos de enemigo que pueden spawnear*/
    private List<GameObject> tankTypes;

    /*Lista con las entidades actuales de un nivel*/
    public List<GameObject> currentEntities;

    /*Lista auxiliar para el manejo de spawns*/
    public List<GameObject> spawnpoints_aux;

    /*Sistema de particulas para el efecto de spawn*/
    public ParticleSystem ps_spawn;

    /*Flag para saber si un nivel ha cargado entero*/
    public bool hasStarted = false;

    /*Posicion inicial del jugador*/
    public Vector3 initial_player_pos;// = new Vector3(11, 2.5f, 17);

    /*Nivel actual*/
    private Level level;
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
        levelIndex = Random.Range(0, levels.Count);
        float xPos = levels[levelIndex].start.transform.position.x;
        float zPos = levels[levelIndex].start.transform.position.z;
        initial_player_pos = new Vector3(xPos - Config.Instance.blockSize, 2.5f, zPos + Config.Instance.blockSize);
        StartCoroutine("SpawnEnemiesAndPlayer");
	}
	
	// Update is called once per frame
	void Update () {

        // Comprobamos si el tanque del jugador fue destruido
        if (player.GetComponent<PlayerTank>().hp <= 0 && (GameOverPanel.activeSelf == false))
        {// Si fue destruido entonces le mostramos la pantalla de Game Over LOST
            GameOverPanel.SetActive(true);
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
            
            if (numberOfEntities == 0)
            {
                LoadNextLevel = true;
                numberOfEntities = -1;
                levels.RemoveAt(levelIndex);
                if (levels.Count == 0)
                {
                    if(GameOverPanel.activeSelf == false)
                    {
                        GameOverPanel.SetActive(true);
                        GameOver.ShowGameOver(GameOverCondition.WIN);
                        hasStarted = false;
                        LoadNextLevel = false;
                    }
                
                }
                else
                {
               
                    levelIndex = Random.Range(0, levels.Count);
                    float xPos = levels[levelIndex].start.transform.position.x;
                    float zPos = levels[levelIndex].start.transform.position.z;
                    initial_player_pos = new Vector3(xPos - Config.Instance.blockSize, 2.5f, zPos + Config.Instance.blockSize);
                    StartCoroutine("Reset");
                    ParticleSystem player_ps = Instantiate(ps_spawn, player.transform.position, player.transform.rotation);
                    player_ps.gameObject.SetActive(true);
                    player_ps.Play();
                    player.SetActive(false);
                    StartCoroutine("SpawnEnemiesAndPlayer");
                }

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
        level = Instantiate(levels[levelIndex],new Vector3(0,50,0), Quaternion.identity);
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
