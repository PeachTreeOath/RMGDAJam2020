using FiveXT.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FiveXT.JoustDoIt
{
    public enum GamePhase
    {
        COUNTING_DOWN,
        JOUSTING,
        JOUST_PAUSE,
        JOUST_RESULTS,
        WINNER_SHOP,
        LOSER_SHOP
    }

    public class GameManager_JoustDoIt : Singleton<GameManager_JoustDoIt>, IGameStartCountdownListener
    {
        public GameObject gameOverCanvas;
        public TextMeshProUGUI winnerText;
        public ScoreWidget p1Hearts;
        public ScoreWidget p2Hearts;
        public GameObject p1RoundVictoryObj;
        public GameObject p2RoundVictoryObj;
        public LanceController p1Lance;
        public LanceController p2Lance;

        [HideInInspector] public bool isGameStarted;
        [HideInInspector] public bool isGameOver;
        [HideInInspector] public GamePhase phase;

        private int p1Points;
        private int p2Points;

        private float phaseTimeElapsed;
        [HideInInspector] public float joustingPhaseDuration = 10;
        private float joustPausePhaseDuration = 1;
        private float joustResultsPhaseDuration = 5;

        private void Start()
        {
            GameStartCountdown.instance.RegisterListener(this);

            phase = GamePhase.COUNTING_DOWN;
            GameStartCountdown.instance.StartCountdown();
        }

        private void Update()
        {
            if (!IsGamePlayable()) return;

            phaseTimeElapsed += Time.deltaTime;
            
            if (phase == GamePhase.JOUSTING)
            {
                if (phaseTimeElapsed > joustingPhaseDuration)
                {
                    phaseTimeElapsed = 0;
                    phase = GamePhase.JOUST_PAUSE;
                }
            }
            else if (phase == GamePhase.JOUST_PAUSE)
            {
                // Just wait a sec

                if (phaseTimeElapsed > joustPausePhaseDuration)
                {
                    // SHOW RESULTS SCENE

                    phaseTimeElapsed = 0;
                    phase = GamePhase.JOUST_RESULTS;
                }
            }
            else if (phase == GamePhase.JOUST_RESULTS)
            {
                // PLAY RESULTS SCENE

                if (phaseTimeElapsed > joustResultsPhaseDuration)
                {
                    phaseTimeElapsed = 0;
                    phase = GamePhase.WINNER_SHOP;
                }
            }
        }

        public void GameStart()
        {
            phase = GamePhase.COUNTING_DOWN;
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

        public void ScorePoint(int playerNum)
        {
            if (playerNum == 0)
            {
                p1Points++;
                p1RoundVictoryObj.SetActive(true);
            }
            else if (playerNum == 1)
            {
                p2Points++;
                p2RoundVictoryObj.SetActive(true);
            }

            SetHearts();
        }

        private void SetHearts()
        {
            p1Hearts.SetIconCount(p1Points);
            p2Hearts.SetIconCount(p2Points);
        }
    }
}
