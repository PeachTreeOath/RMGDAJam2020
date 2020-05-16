using FiveXT.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FiveXT.DuelOfTheDates
{
    public enum GamePhase
    {
        INVESTIGATING,
        ANSWERING
    }

    public class GameManager_DuelOfTheDates : Singleton<GameManager_DuelOfTheDates>, IGameStartCountdownListener
    {
        public GameObject gameOverCanvas;
        public TextMeshProUGUI winnerText;

        [HideInInspector] public bool isGameStarted;
        [HideInInspector] public bool isGameOver;
        [HideInInspector] public GamePhase phase;

        private void Start()
        {
            GameStartCountdown.instance.RegisterListener(this);
        }

        private void Update()
        {
            if (!IsGamePlayable()) return;

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
