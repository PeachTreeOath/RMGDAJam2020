using FiveXT.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FiveXT.JoustDoIt
{
    public class LanceController : MonoBehaviour, IControllable
    {
        public int playerNum;
        public float moveSpeed;
        public float bobSpeed;
        public float bobRadius;
        public SpriteRenderer spr;
        public Sprite normalLance;
        public Sprite halfLance;

        private Vector2 origPos;

        private Vector2 movementInput;
        private Vector2 controllerAdjust;

        private void Start()
        {
            origPos = transform.position;

            PlayerControllerManager.instance.RegisterControllable(this, playerNum);
        }

        // Update is called once per frame
        void Update()
        {
            if (GameManager_JoustDoIt.instance.phase != GamePhase.JOUSTING) return;

            float tempBobRadius = bobRadius;
            if (playerNum == 0 && GameManager_JoustDoIt.instance.p2BoughtItems.Contains(5)) // Beer
                tempBobRadius *= 2f;
            else if (playerNum == 1 && GameManager_JoustDoIt.instance.p1BoughtItems.Contains(5)) // Beer
                tempBobRadius *= 2f;

            float tempBobSpeed = bobSpeed;
            if (playerNum == 0 && GameManager_JoustDoIt.instance.p2BoughtItems.Contains(3)) // Angry horse
                tempBobSpeed *= 2f;
            else if (playerNum == 1 && GameManager_JoustDoIt.instance.p1BoughtItems.Contains(3)) // Angry horse
                tempBobSpeed *= 2f;

            float px = Time.time * tempBobSpeed + (playerNum * 10000);
            float py = (Time.time * tempBobSpeed) + 5000 + (playerNum * 10000);
            float x = (Mathf.PerlinNoise(px, px) - 0.5f) * tempBobRadius + origPos.x;
            float y = (Mathf.PerlinNoise(py, py) - 0.5f) * tempBobRadius + origPos.y;

            transform.position = new Vector2(x, y) + controllerAdjust;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (GameManager_JoustDoIt.instance.phase != GamePhase.JOUSTING) return;

            float h = movementInput.x * Time.fixedDeltaTime * moveSpeed;
            float v = movementInput.y * Time.fixedDeltaTime * moveSpeed;

            if (playerNum == 0 && GameManager_JoustDoIt.instance.p2BoughtItems.Contains(2)) // Heavy lance
            {
                h *= 0.66f;
                v *= 0.66f;
            }
            else if (playerNum == 1 && GameManager_JoustDoIt.instance.p1BoughtItems.Contains(2)) // Heavy lance
            {
                h *= 0.66f;
                v *= 0.66f;
            }

            if (playerNum == 0 && GameManager_JoustDoIt.instance.p2BoughtItems.Contains(4)) // Confusion
            {
                h = -h;
                v = -v;
            }
            else if (playerNum == 1 && GameManager_JoustDoIt.instance.p1BoughtItems.Contains(4)) // Confusion
            {
                h = -h;
                v = -v;
            }

            controllerAdjust += new Vector2(h, v);
        }

        private void OnDestroy()
        {
            PlayerControllerManager.instance.DeregisterControllable(this, playerNum);
        }

        public void OnMove(InputValue value)
        {
            if (GameManager_JoustDoIt.instance.phase != GamePhase.JOUSTING) return;

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

        public float GetDistanceFromCenter()
        {
            return Vector2.Distance(transform.position, origPos);
        }

        public void Reset()
        {
            transform.position = origPos;
            controllerAdjust = Vector2.zero;
            movementInput = Vector2.zero;

            spr.sprite = normalLance;

            if (playerNum == 0 && GameManager_JoustDoIt.instance.p2BoughtItems.Contains(1)) // Nearsighted
                spr.sprite = halfLance;
            else if (playerNum == 1 && GameManager_JoustDoIt.instance.p1BoughtItems.Contains(1)) // Nearsighted
                spr.sprite = halfLance;
        }

        public void ShowLance()
        {
            spr.sprite = normalLance;
        }
    }
}