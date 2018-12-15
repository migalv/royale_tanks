using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using _Config;

public class MainMenu : MonoBehaviour {

    public AudioManager audioManager;

    private void Start()
    {
        if (audioManager == null)
        {
            Debug.LogWarning("Audio Manager not found");
            return;
        }
        // Activamos la música de fondo del menu principal
        audioManager.Play(Config.Instance.mainMenuSource);
    }

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
