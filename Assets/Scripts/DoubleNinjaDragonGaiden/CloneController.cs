﻿using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FiveXT.DoubleNinjaDragonGaiden
{
    public class CloneController : MonoBehaviour, IControllable
    {
        public int playerNum;
        public float moveSpeed;
        public SpriteRenderer spr;

        private Vector2 movementInput;

        private void Start()
        {
            PlayerControllerManager.instance.RegisterControllable(this, playerNum);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!GameManager_DoubleNinjaDragonGaiden.instance.IsGamePlayable()) return;

            float h = movementInput.x * Time.fixedDeltaTime * moveSpeed;
            float v = movementInput.y * Time.fixedDeltaTime * moveSpeed;

            transform.Translate(new Vector2(h, v));

            if (h > 0)
                spr.flipX = true;
            else
                spr.flipX = false;
        }

        private void OnDestroy()
        {
            PlayerControllerManager.instance.DeregisterControllable(this, playerNum);
        }

        public void OnMove(InputValue value)
        {
            if (!GameManager_DoubleNinjaDragonGaiden.instance.IsGamePlayable()) return;

            movementInput = value.Get<Vector2>();
        }

        public void OnAim(InputValue value)
        {
            // Do nothing
        }

        public void OnAction1()
        {
            // Do nothing
        }

        public void OnAction2()
        {
            // Do nothing
        }

        public void OnLeftTriggerAction()
        {
            // BOMB
        }

        public void OnRightTriggerAction()
        {
            // Do nothing
        }

        public void OnStart()
        {
            // Do nothing
        }
    }
}