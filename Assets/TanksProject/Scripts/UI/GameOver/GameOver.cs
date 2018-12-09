using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _GameOver
{
    public class GameOver : MonoBehaviour
    {
        public static Text GameOverMessage1;

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
            switch (goc)
            {
                case GameOverCondition.WIN:
                    GameOver.ShowPlayerWon();
                    break;
                case GameOverCondition.LOST:
                    GameOver.ShowPlayerLost();
                    break;
                default:
                    break;
            }
        }

        static void ShowPlayerWon()
        {
            GameOverMessage1.text = Config.Instance.winMessage;
        }
        static void ShowPlayerLost()
        {

        }
    }
}
