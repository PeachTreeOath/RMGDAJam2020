﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FiveXT.Core
{
    public class PlayerController : MonoBehaviour, IControllable
    {
        [HideInInspector] public int playerNum;
        [HideInInspector] public IControllable controlledObject;

        void Awake()
        {
            PlayerControllerManager.instance.RegisterPlayer(this);
            transform.SetParent(PlayerControllerManager.instance.transform);
        }

        public void OnMove(InputValue value)
        {
            if (controlledObject != null)
                controlledObject.OnMove(value);
        }

        public void OnAim(InputValue value)
        {
            if (controlledObject != null)
                controlledObject.OnAim(value);
        }

        public void OnAction1()
        {
            if (controlledObject != null)
                controlledObject.OnAction1();
        }

        public void OnAction2()
        {
            if (controlledObject != null)
                controlledObject.OnAction2();
        }

        public void OnStart()
        {
            if (GameLobbyStarter.instance != null)
                GameLobbyStarter.instance.StartGame();
            else if (controlledObject != null)
                controlledObject.OnStart();
        }
    }
}