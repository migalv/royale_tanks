using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void QuitGame()
    {
        Application.Quit();
    }
    // Función que inicia el juego
    public void PlayGame()
    {   // Cargamos la Game Scene donde se desarrolla el juego
        // En ella se cargará el Level Manager que inicializará la partida.
        SceneManager.LoadScene(Config.Instance.levelScene);
    }
}
