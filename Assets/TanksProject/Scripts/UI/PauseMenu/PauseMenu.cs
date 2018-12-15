﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using _Config;

public class PauseMenu : MonoBehaviour{

    // ########################################
    // Variables
    // ########################################
    #region Variables
    // Boolean que determina si el juego está en pausa o corriendo
    public static bool isPaused = false;

    // Variable que apunta al fondo del Menu de pausa
    public GameObject pauseMenuBackground;
    // Variable que apunta al botón de pausa
    public GameObject pauseBtn;

    // GUIAnimFREE objects for the pause menu Panel
    public GUIAnimFREE p_menuPanel;

    #endregion // Variables

    void Update()
    {
        // Si el jugador pulsa la tecla escape el juego se pausa o se reanuda
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {   // Si el juego está pausado el juego se reanuda
                ResumeGame();
            }
            else
            {   // Si el juego está corriendo el juego se pausa
                PauseGame();
            }
        }
    }

    #region MonoBehaviour

    private void OnEnable()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Awake()
    {

        if (enabled)
        {
            // Set GUIAnimSystemFREE.Instance.m_AutoAnimation to false in Awake() will let you control all GUI Animator elements in the scene via scripts.
            GUIAnimSystemFREE.Instance.m_AutoAnimation = false;
        }
    }

    void ShowPauseMenu()
    {
        // MoveIn the pause menu Panel
        p_menuPanel.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }

    void HidePauseMenu()
    {
        // MoveIn the pause menu Panel
        p_menuPanel.PlayOutAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
    }

    // Callback para el botón de salir del juego
    public void QuitGame()
    {   // Cargamos la pantalla principal con el menu
        SceneManager.LoadScene(Config.Instance.menuScene);
        
        
    }

    // Función que sirve para reanudar el juego escondiendo el menu de pausa
    public void ResumeGame()
    {
        // Hide the pause menu background
        pauseMenuBackground.SetActive(false);
        pauseBtn.SetActive(true);
        HidePauseMenu();
        Time.timeScale = 1f;
        isPaused = false;
    }

    // Función que sirve para pausar el juego mostrando el menu de pausa
    public void PauseGame()
    {
        // Show the pause menu background
        pauseMenuBackground.SetActive(true);
        pauseBtn.SetActive(false);
        ShowPauseMenu();
        Time.timeScale = 0f;
        isPaused = true;
    }

    #endregion // MonoBehaviour
}
