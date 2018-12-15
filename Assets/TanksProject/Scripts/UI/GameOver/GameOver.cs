using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using _Config;

namespace _GameOver
{
    public class GameOver : MonoBehaviour{

        public Text GameOverMessage1;
        public GameObject GameOverMessage2;
        public GUIAnimFREE GameOverPanel;
        public GameObject PauseBtn;
        public static Text sGameOverMessage1;
        public static GameObject sGameOverMessage2;
        public static GUIAnimFREE sGameOverPanel;
        public static GameObject sPauseBtn;

        private void Awake()
        {
            sGameOverMessage1 = GameOverMessage1;
            sGameOverMessage2 = GameOverMessage2;
            sGameOverPanel = GameOverPanel;
            sPauseBtn = PauseBtn;
        }

        public void NewGame()
        {
            SceneManager.LoadScene(Config.Instance.levelScene);
        }
        public void QuitGame()
        {   // Cargamos la pantalla principal con el menu
            SceneManager.LoadScene(Config.Instance.menuScene);
        }
        public static void ShowGameOver(GameOverCondition goc)
        {
            sPauseBtn.SetActive(false);
            switch (goc)
            {
                case GameOverCondition.WIN:
                    ShowPlayerWon();
                    break;
                case GameOverCondition.LOST:
                    ShowPlayerLost();
                    break;
                default:
                    break;
            }
            sGameOverPanel.PlayInAnims(GUIAnimSystemFREE.eGUIMove.SelfAndChildren);
        }

        static void ShowPlayerWon()
        {
            sGameOverMessage1.text = Config.Instance.winMessage1;
            sGameOverMessage2.SetActive(true);
        }
        static void ShowPlayerLost()
        {
            sGameOverMessage1.text = Config.Instance.lostMessage1;
        }

    }
}
