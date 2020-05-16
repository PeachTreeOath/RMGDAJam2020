using System;
using System.Collections;
using System.Collections.Generic;
using FiveXT.SnakeSnipe;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FiveXT.Core
{
    public class PlayerControllerManager : Singleton<PlayerControllerManager>
    {
        [HideInInspector] public List<PlayerController> players = new List<PlayerController>();
        [HideInInspector] public List<IControllerSpawnListener> controllerSpawnListeners = new List<IControllerSpawnListener>();

        private int numPlayers;

        protected override void Awake()
        {
            base.Awake();
            SetDontDestroy();
        }

        public void RegisterControllerSpawnListener(IControllerSpawnListener listener)
        {
            controllerSpawnListeners.Add(listener);
        }

        public void DeregisterControllerSpawnListener(IControllerSpawnListener listener)
        {
            controllerSpawnListeners.Remove(listener);
        }

        public void RegisterPlayer(PlayerController playerController)
        {
            playerController.playerNum = numPlayers;
            players.Add(playerController);
            numPlayers++;

            foreach (IControllerSpawnListener listener in controllerSpawnListeners)
            {
                listener.OnPlayerSpawned(playerController.playerNum);
            }
        }

        public void RegisterControllable(IControllable controller, int playerNum)
        {
            players[playerNum].controlledObject = controller;
        }

        public bool AreAllPlayersReady()
        {
            return numPlayers > 1;
        }
    }
}