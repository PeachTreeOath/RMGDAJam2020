using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FiveXT.DoubleNinjaDragonGaiden
{
    public class NinjaController : MonoBehaviour, IControllable
    {
        public int playerNum;
        public float moveSpeed;
        public SpriteRenderer spr;
        public GameObject slashObject;
        public float attackDuration;

        private Vector2 movementInput;
        private Vector2 attackVector;
        private float attackTimeElapsed;

        private bool isAttacking;
        private bool isDead;

        private void Start()
        {
            PlayerControllerManager.instance.RegisterControllable(this, playerNum);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (isDead) return;

            if (isAttacking)
            {
                attackTimeElapsed += Time.fixedDeltaTime;

                float h = attackVector.x * Time.fixedDeltaTime * EaseOutQuart(moveSpeed * 5, 0, attackTimeElapsed / attackDuration);
                float v = attackVector.y * Time.fixedDeltaTime * EaseOutQuart(moveSpeed * 5, 0, attackTimeElapsed / attackDuration);

                transform.Translate(new Vector2(h, v));

                if (attackTimeElapsed > attackDuration)
                {
                    isAttacking = false;
                    slashObject.SetActive(false);
                }
            }
            else
            {
                if (!GameManager_DoubleNinjaDragonGaiden.instance.IsGamePlayable()) return;

                float h = movementInput.x * Time.fixedDeltaTime * moveSpeed;
                float v = movementInput.y * Time.fixedDeltaTime * moveSpeed;

                transform.Translate(new Vector2(h, v));

                if (h > 0)
                    spr.flipX = true;
                else if (h < 0)
                    spr.flipX = false;

                // Save off last attack direction
                if (h != 0 && v != 0)
                    attackVector = movementInput;
            }
        }

        private void OnDestroy()
        {
            PlayerControllerManager.instance.DeregisterControllable(this, playerNum);
        }

        public void OnMove(InputValue value)
        {
            // Do nothing
        }

        public void OnAim(InputValue value)
        {
            if (isDead) return;

            if (!GameManager_DoubleNinjaDragonGaiden.instance.IsGamePlayable()) return;

            movementInput = value.Get<Vector2>();
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
            if (isDead) return;

            if (!GameManager_DoubleNinjaDragonGaiden.instance.IsGamePlayable()) return;

            if (isAttacking) return;

            if (attackVector == Vector2.zero)
            {
                if (playerNum == 0)
                    attackVector = new Vector2(1, 0);
                else
                    attackVector = new Vector2(-1, 0);
            }

            float h = attackVector.x;
            float v = attackVector.y;

            slashObject.SetActive(true);

            Vector2 facingVector = new Vector2(h, v).normalized;
            slashObject.transform.localPosition = facingVector * 0.125f;
            float angle = Mathf.Atan2(facingVector.y, facingVector.x) * Mathf.Rad2Deg;
            slashObject.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            attackTimeElapsed = 0;
            isAttacking = true;
        }

        public void OnStart()
        {
            if (GameManager_DoubleNinjaDragonGaiden.instance.isGameOver)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        /*
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (isDead) return;

            if (collision.tag.Equals("Slash") && collision.GetComponentInParent<NinjaController>().playerNum != playerNum)
            {
                Die();
            }
        }
        */

        public void Die()
        {
            if (isDead) return;

            isDead = true;
            slashObject.SetActive(false);

            GameManager_DoubleNinjaDragonGaiden.instance.OnNinjaDeath(playerNum);
        }

        public void Revive()
        {
            isDead = false;
            isAttacking = false;
            attackVector = Vector2.zero;
            movementInput = Vector2.zero;
        }

        private float EaseOutQuart(float start, float end, float value)
        {
            value--;
            end -= start;
            return -end * (value * value * value * value - 1) + start;
        }
    }
}