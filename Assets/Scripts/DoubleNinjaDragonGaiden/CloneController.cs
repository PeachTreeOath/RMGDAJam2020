using FiveXT.Core;
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
        public SpriteRenderer logSpr;
        public GameObject smokePrefab;
        public GameObject deathPrefab;
        public float smokeBombCooldownTime;
        public SmokeBombMeter smokeBombMeter;

        private float smokeBombTimeElapsed;
        private bool isDead;
        private Vector2 movementInput;

        private void Start()
        {
            smokeBombTimeElapsed = smokeBombCooldownTime;
            PlayerControllerManager.instance.RegisterControllable(this, playerNum);
        }

        void Update()
        {
            if (isDead) return;

            if (!GameManager_DoubleNinjaDragonGaiden.instance.IsGamePlayable()) return;

            smokeBombMeter.SetProgress(smokeBombTimeElapsed / smokeBombCooldownTime);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isDead) return;

            if (!GameManager_DoubleNinjaDragonGaiden.instance.IsGamePlayable()) return;

            smokeBombTimeElapsed += Time.fixedDeltaTime;

            float h = movementInput.x * Time.fixedDeltaTime * moveSpeed;
            float v = movementInput.y * Time.fixedDeltaTime * moveSpeed;

            transform.Translate(new Vector2(h, v));

            if (h > 0)
                spr.flipX = true;
            else if (h < 0)
                spr.flipX = false;
        }

        private void OnDestroy()
        {
            PlayerControllerManager.instance.DeregisterControllable(this, playerNum);
        }

        public void OnMove(InputValue value)
        {
            if (isDead) return;

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
            if (isDead) return;

            if (!GameManager_DoubleNinjaDragonGaiden.instance.IsGamePlayable()) return;

            ThrowSmokeBomb();
        }

        public void OnRightTriggerAction()
        {
            // Do nothing
        }

        public void OnStart()
        {
            // Do nothing
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isDead) return;

            if (collision.tag.Equals("Slash") && collision.GetComponentInParent<NinjaController>().playerNum != playerNum)
            {
                Die();
            }
        }

        private void Die()
        {
            GameObject death = Instantiate(deathPrefab);
            death.transform.position = transform.position;

            spr.enabled = false;
            logSpr.enabled = true;
            isDead = true;
            smokeBombMeter.SetProgress(0);

            GameManager_DoubleNinjaDragonGaiden.instance.OnCloneDeath(playerNum);
        }

        public void Revive()
        {
            spr.enabled = true;
            logSpr.enabled = false;
            isDead = false;
            smokeBombMeter.SetProgress(0);
        }

        public void ResetSmokeMeter()
        {
            smokeBombTimeElapsed = smokeBombCooldownTime;
        }

        public void ThrowSmokeBomb()
        {
            if (smokeBombTimeElapsed >= smokeBombCooldownTime)
            {
                GameObject smoke = Instantiate(smokePrefab);
                smoke.transform.position = transform.position;
                smokeBombTimeElapsed = 0;
            }
        }
    }
}