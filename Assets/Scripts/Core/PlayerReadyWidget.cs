using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FiveXT.Core
{
    public class PlayerReadyWidget : MonoBehaviour, IControllerSpawnListener
    {
        // Inspector set
        public int playerNum; // 0-based
        public GameObject readyText;

        // Start is called before the first frame update
        void Start()
        {
            PlayerControllerManager.instance.RegisterControllerSpawnListener(this);
        }

        public void OnPlayerSpawned(int num)
        {
            if (playerNum == num)
                readyText.SetActive(true);
        }

        private void OnDestroy()
        {
            PlayerControllerManager.instance.DeregisterControllerSpawnListener(this);
        }
    }
}