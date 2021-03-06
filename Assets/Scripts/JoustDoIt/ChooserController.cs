﻿using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FiveXT.JoustDoIt
{
    public class ChooserController : MonoBehaviour, IControllable
    {
        public int playerNum;

        private Vector2 movementInput;
        private bool isAcceptingInput;
        private const float threshold = 0.8f;

        private void Start()
        {
            PlayerControllerManager.instance.RegisterControllable(this, playerNum);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (GameManager_JoustDoIt.instance.phase != GamePhase.WINNER_SHOP) return;

            float h = movementInput.x;
            float v = movementInput.y;

            transform.Translate(new Vector2(h, v));
        }

        private void OnDestroy()
        {
            PlayerControllerManager.instance.DeregisterControllable(this, playerNum);
        }

        public void OnMove(InputValue value)
        {
            if (GameManager_JoustDoIt.instance.phase != GamePhase.WINNER_SHOP) return;

            movementInput = value.Get<Vector2>();

            if (isAcceptingInput && movementInput.x < -threshold)
            {
                ShopView.instance.MoveSelectionLeft(playerNum);
                isAcceptingInput = false;
            }
            else if (isAcceptingInput && movementInput.x > threshold)
            {
                ShopView.instance.MoveSelectionRight(playerNum);
                isAcceptingInput = false;
            }
            else if (movementInput.x > -threshold && movementInput.x < threshold)
            {
                isAcceptingInput = true;
            }
        }

        public void OnAim(InputValue value)
        {
            // Do nothing
        }

        public void OnAction1()
        {
            if (GameManager_JoustDoIt.instance.phase != GamePhase.WINNER_SHOP) return;

            ShopView.instance.BuyItem(playerNum);
        }

        public void OnAction2()
        {
            // Do nothing
        }

        public void OnLeftTriggerAction()
        {
            // Do nothing
        }

        public void OnRightTriggerAction()
        {
            // Do nothing
        }

        public void OnStart()
        {
            if (GameManager_JoustDoIt.instance.isGameOver)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}