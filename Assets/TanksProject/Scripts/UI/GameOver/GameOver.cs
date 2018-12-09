using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _GameOver
{
    public class GameOver : MonoBehaviour
    {

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

        }
        static void ShowPlayerLost()
        {

        }
    }
}
