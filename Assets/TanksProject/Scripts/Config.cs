    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Config
{
    public enum GameOverCondition { WIN, LOST };

    public class Config : Singleton<Config>
    {
        // ########################################
        // Escenas
        // ########################################
        #region Escenas

        // Variable que hace referencia al nombre de la escena donde se cargan el juego
        public string levelScene = "InGameScene";
        // Variable que hace referencia al nombre de la escena donde se muestra el menu del juego
        public string menuScene = "TanksMenu";

        #endregion // Escenas

        // ########################################
        // Messages
        // ########################################
        #region Messages

        // Variables con los posibles mensajes del juego
        public string winMessage1 = "YOU WON !";
        // Variables con los posibles mensajes del juego
        public string lostMessage1 = "YOU LOST";

        #endregion

        // ########################################
        // blockVars
        // ########################################
        #region blockVars

        // Los bloques miden 2.5f, pero nos interesa coger la mitad de ese valor para spawnear cosas en el centro del bloque
        public float blockSize = 2.5f/2;


        #endregion

        // ########################################
        // Audio Names
        // ########################################
        #region AudioNames

        // Nombre del clip del sonido de fondo del Menu principal
        public string mainMenuSource = "MainMenu";

        // Nombre del Audio Group principal
        public string masterVolume = "MasterVolume";

        #endregion
    }
}


