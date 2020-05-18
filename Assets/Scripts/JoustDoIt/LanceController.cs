using FiveXT.Core;
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
            float px = Time.time * bobSpeed + (playerNum * 10000);
            float py = (Time.time * bobSpeed) + 5000 + (playerNum * 10000);
            float x = (Mathf.PerlinNoise(px, px) - 0.5f) * bobRadius + origPos.x;
            float y = (Mathf.PerlinNoise(py, py) - 0.5f) * bobRadius + origPos.y;

            transform.position = new Vector2(x, y) + controllerAdjust;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            float h = movementInput.x * Time.fixedDeltaTime * moveSpeed;
            float v = movementInput.y * Time.fixedDeltaTime * moveSpeed;

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
    }
}