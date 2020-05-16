using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FiveXT.Core
{
    public class GameLobbyStarter : Singleton<GameLobbyStarter>
    {
        // Inspector set
        public string sceneName;

        public void StartGame()
        {
            if (PlayerControllerManager.instance.AreAllPlayersReady())
                SceneManager.LoadScene(sceneName);
        }
    }
}