using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameOverCondition { WIN, LOST };

public class Config : Singleton<Config>{

    // ########################################
    // Escenas
    // ########################################
    #region Escenas

    // Variable que hace referencia al nombre de la escena donde se cargan el juego
    public string levelScene = "TestLevel";
    // Variable que hace referencia al nombre de la escena donde se muestra el menu del juego
    public string menuScene = "tanks_menu";

    #endregion // Escenas

    // ########################################
    // Messages
    // ########################################
    #region Messages

    // Variables con los posibles mensajes del juego
    public string winMessage = "YOU WON !";

    #endregion
}


