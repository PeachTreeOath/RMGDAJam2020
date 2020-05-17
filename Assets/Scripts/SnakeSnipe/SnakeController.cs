using FiveXT.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace FiveXT.SnakeSnipe
{
    public class SnakeController : MonoBehaviour, IControllable
    {
        // Inspector set
        public int playerNum;
        public GameObject bodyPrefab;
        public GameObject bulletPrefab;
        public GameObject shotMeter;
        public Sprite snakeHead;
        public Sprite snakeBody;
        public Sprite snakeBodyDark;
        public Sprite snakeTail;

        public float moveSpeed;
        public float rotSpeed;
        public int beginSize;
        public int minDistance;
        public float shotCooldownInSecs;
        public List<Transform> bodyParts = new List<Transform>();

        private PlayerInputActions inputAction;
        private Vector2 movementInput;

        private Transform currBodyPart;
        private float shotTimeElapsed;

        private Queue<Vector2> prevPositions = new Queue<Vector2>();
        private Queue<float> prevRotations = new Queue<float>();

        private float shotMeterSize;
        private Vector3 shotMeterDelta = new Vector3(0, 0.55f, 0);

        private void Awake()
        {
            PlayerControllerManager.instance.RegisterControllable(this, playerNum);

            shotMeterSize = shotMeter.transform.localScale.x;
            shotTimeElapsed = shotCooldownInSecs;
            shotMeter.transform.localScale = new Vector3(0, shotMeter.transform.localScale.y, 1);
        }

        // Start is called before the first frame update
        void Start()
        {
            for (int i = 1; i < beginSize; i++)
            {
                AddBodyPart(i == beginSize - 1);
            }
        }

        private void OnDestroy()
        {
            PlayerControllerManager.instance.DeregisterControllable(this, playerNum);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (!GameManager_SnakeSnipe.instance.IsGamePlayable()) return;

            shotTimeElapsed += Time.fixedDeltaTime;

            float h = movementInput.x;
            float v = movementInput.y;

            float currSpeed = (moveSpeed + (0.5f * (beginSize - bodyParts.Count))) * Time.fixedDeltaTime;

            Rigidbody2D rigidbody = bodyParts[0].GetComponent<Rigidbody2D>();
            rigidbody.MovePosition(rigidbody.position + (Vector2)(rigidbody.transform.up * currSpeed));
            rigidbody.MoveRotation(rigidbody.rotation - h * rotSpeed * Time.fixedDeltaTime);

            if (rigidbody.position.x > GameManager_SnakeSnipe.instance.brBounds.x ||
               rigidbody.position.x < GameManager_SnakeSnipe.instance.ulBounds.x ||
               rigidbody.position.y < GameManager_SnakeSnipe.instance.brBounds.y ||
               rigidbody.position.y > GameManager_SnakeSnipe.instance.ulBounds.y)
                rigidbody.position = Vector3.zero; // In case they tunnel out of the arena

            prevPositions.Enqueue(rigidbody.position);
            prevRotations.Enqueue(rigidbody.rotation);

            if (prevPositions.Count > 700)
                prevPositions.Dequeue();

            if (prevRotations.Count > 700)
                prevRotations.Dequeue();

            for (int i = 1; i < bodyParts.Count; i++)
            {
                if (prevPositions.Count <= i * minDistance) return;


                currBodyPart = bodyParts[i];

                currBodyPart.position = prevPositions.ElementAt(prevPositions.Count - i * minDistance);
                currBodyPart.GetComponent<Rigidbody2D>().rotation = prevRotations.ElementAt(prevRotations.Count - i * minDistance);
                currBodyPart.GetComponent<SpriteRenderer>().enabled = true;
            }

            if (shotTimeElapsed < shotCooldownInSecs)
            {
                shotMeter.transform.position = bodyParts[0].position + shotMeterDelta;
                float percent = shotTimeElapsed / shotCooldownInSecs;
                shotMeter.transform.localScale = new Vector3(percent * shotMeterSize, shotMeter.transform.localScale.y, 1);
            }
            else
            {
                shotMeter.transform.localScale = new Vector3(0, shotMeter.transform.localScale.y, 1);
            }
        }

        public void OnMove(InputValue value)
        {
            if (!GameManager_SnakeSnipe.instance.IsGamePlayable()) return;

            movementInput = value.Get<Vector2>();
        }

        public void OnAim(InputValue value)
        {
            // Do nothing
        }

        public void OnAction1()
        {
            if (!GameManager_SnakeSnipe.instance.IsGamePlayable()) return;

            if (shotTimeElapsed > shotCooldownInSecs)
            {
                Instantiate(bulletPrefab, bodyParts[0].position + (bodyParts[0].transform.up), bodyParts[0].rotation);
                shotTimeElapsed = 0;
            }
        }

        public void OnAction2()
        {
            // Do nothing
        }

        public void OnStart()
        {
            if (GameManager_SnakeSnipe.instance.isGameOver)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void TakeHit()
        {
            // Destroy a body part
            if (bodyParts.Count == 2)
            {
                GameManager_SnakeSnipe.instance.GameOver(playerNum);
            }
            else
            {
                Transform partToDestroy = bodyParts[bodyParts.Count - 2];
                bodyParts.Remove(partToDestroy);
                partToDestroy.GetComponent<SpriteRenderer>().sprite = snakeBodyDark;
            }
        }

        private void AddBodyPart(bool isTail)
        {
            GameObject newObj = Instantiate(bodyPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation);
            newObj.tag = isTail ? "Tail" : "Body";

            Transform newPart = newObj.GetComponent<Transform>();
            newPart.SetParent(transform);

            SpriteRenderer spriteRenderer = newObj.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = isTail ? snakeTail : snakeBody;
            spriteRenderer.enabled = false;

            bodyParts.Add(newPart);
        }
    }
}
