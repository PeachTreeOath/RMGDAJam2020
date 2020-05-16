using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FiveXT.SnakeSnipe
{
    public class GameManager_SnakeSnipe : Singleton<GameManager_SnakeSnipe>, IGameStartCountdownListener
    {
        // Inspector set
        public GameObject bombPrefab;
        public GameObject gameOverCanvas;
        public TextMeshProUGUI winnerText;
        public Vector2 ulBounds;
        public Vector2 brBounds;
        public float bombSpawnTime;

        [HideInInspector] public bool isGameStarted;
        [HideInInspector] public bool isGameOver;

        private float bombTimeElapsed;
        private float currBombSpawnTime;

        private void Start()
        {
            GameStartCountdown.instance.RegisterListener(this);

            currBombSpawnTime = bombSpawnTime;
        }

        private void Update()
        {
            if (!IsGamePlayable()) return;

            bombTimeElapsed += Time.deltaTime;

            if (bombTimeElapsed > currBombSpawnTime)
            {
                SpawnBomb();
                bombTimeElapsed = 0;
            }
        }

        private void SpawnBomb()
        {
            GameObject bomb = Instantiate(bombPrefab);

            float x = Random.Range(ulBounds.x, brBounds.x);
            float y = Random.Range(brBounds.y, ulBounds.y);

            bomb.transform.position = new Vector2(x, y);
            currBombSpawnTime *= 0.975f;
        }

        public void GameStart()
        {
            isGameStarted = true;
        }

        public void GameOver(int playerNum)
        {
            isGameOver = true;
            gameOverCanvas.SetActive(true);
            winnerText.text = "Player " + (playerNum + 1) + " wins!";
        }

        public bool IsGamePlayable()
        {
            return isGameStarted && !isGameOver;
        }
    }
}
