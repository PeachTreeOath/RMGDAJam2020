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
        public Knight p1Knight;
        public Knight p2Knight;
        public TextMeshProUGUI p1CashText;
        public TextMeshProUGUI p2CashText;
        public GameObject shopObject;

        [HideInInspector] public bool isGameStarted;
        [HideInInspector] public bool isGameOver;
        [HideInInspector] public GamePhase phase;

        private int p1Points;
        private int p2Points;
        [HideInInspector] public int p1Cash;
        [HideInInspector] public int p2Cash;

        [HideInInspector] public List<int> p1BoughtItems = new List<int>();
        [HideInInspector] public List<int> p2BoughtItems = new List<int>();

        private float phaseTimeElapsed;
        [HideInInspector] public float joustingPhaseDuration = 5;
        private float joustPausePhaseDuration = 1;
        private float joustResultsPhaseDuration = 0;

        private void Start()
        {
            GameStartCountdown.instance.RegisterListener(this);

            phase = GamePhase.COUNTING_DOWN;
            GameStartCountdown.instance.StartCountdown();
        }

        private void Update()
        {
            if (isGameOver) return;

            phaseTimeElapsed += Time.deltaTime;

            if (phase == GamePhase.JOUSTING)
            {
                if (phaseTimeElapsed > joustingPhaseDuration)
                {
                    p1Lance.ShowLance();
                    p2Lance.ShowLance();

                    phaseTimeElapsed = 0;
                    phase = GamePhase.JOUST_PAUSE;
                }
            }
            else if (phase == GamePhase.JOUST_PAUSE)
            {
                // Just wait a sec

                if (phaseTimeElapsed > joustPausePhaseDuration)
                {
                    // SHOW RESULTS SCENE...maybe

                    int winnerNum = GetWinner();
                    ScorePoint(winnerNum);
                    if (winnerNum == 0)
                    {
                        p1Cash += 3;
                        p2Cash += 2;
                    }
                    else
                    {
                        p1Cash += 2;
                        p2Cash += 3;
                    }

                    if (isGameOver) return;

                    phaseTimeElapsed = 0;
                    phase = GamePhase.JOUST_RESULTS;
                }
            }
            else if (phase == GamePhase.JOUST_RESULTS)
            {
                // PLAY RESULTS SCENE

                if (phaseTimeElapsed > joustResultsPhaseDuration)
                {
                    p1BoughtItems.Clear();
                    p2BoughtItems.Clear();

                    shopObject.SetActive(true);
                    ShopView.instance.InitShop();

                    phaseTimeElapsed = 0;
                    phase = GamePhase.WINNER_SHOP;
                }
            }
        }

        private int GetWinner()
        {
            float p1Dist = p1Lance.GetDistanceFromCenter();
            float p2Dist = p2Lance.GetDistanceFromCenter();

            if (p1Dist < p2Dist)
                return 0;
            else return 1;
        }

        public void GameStart()
        {
            phaseTimeElapsed = 0;
            phase = GamePhase.JOUSTING;
        }

        public void GameOver(int playerNum)
        {
            p1RoundVictoryObj.SetActive(false);
            p2RoundVictoryObj.SetActive(false);

            isGameOver = true;
            gameOverCanvas.SetActive(true);
            winnerText.text = "Player " + (playerNum + 1) + " wins!";
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

            if (p1Points == 5)
                GameOver(0);
            else if (p2Points == 5)
                GameOver(1);
        }

        public void GotoJoustingPhase()
        {
            shopObject.SetActive(false);
            p1RoundVictoryObj.SetActive(false);
            p2RoundVictoryObj.SetActive(false);

            phaseTimeElapsed = 0;
            phase = GamePhase.COUNTING_DOWN;
            GameStartCountdown.instance.StartCountdown();

            p1Lance.Reset();
            p2Lance.Reset();
            p1Knight.Reset();
            p2Knight.Reset();
        }

        private void SetHearts()
        {
            p1Hearts.SetIconCount(p1Points);
            p2Hearts.SetIconCount(p2Points);
        }

        public void UpdateCash()
        {
            p1CashText.text = "P1: $" + p1Cash;
            p2CashText.text = "P2: $" + p2Cash;
        }
    }
}
