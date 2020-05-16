using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FiveXT.DuelOfTheDates
{
    public class ChooserController : MonoBehaviour, IControllable
    {
        public int playerNum;

        private Vector2 movementInput;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!GameManager_DuelOfTheDates.instance.IsGamePlayable()) return;

            if (GameManager_DuelOfTheDates.instance.phase != GamePhase.INVESTIGATING) return;

            float h = movementInput.x;
            float v = movementInput.y;

            transform.Translate(new Vector2(h, v));
        }

        public void OnMove(InputValue value)
        {
            if (!GameManager_DuelOfTheDates.instance.IsGamePlayable()) return;

            if (GameManager_DuelOfTheDates.instance.phase != GamePhase.INVESTIGATING) return;

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

        public void OnStart()
        {
            if (GameManager_DuelOfTheDates.instance.isGameOver)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}