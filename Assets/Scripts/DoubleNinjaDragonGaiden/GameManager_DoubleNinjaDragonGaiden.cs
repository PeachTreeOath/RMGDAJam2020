using FiveXT.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FiveXT.DoubleNinjaDragonGaiden
{
    public class GameManager_DoubleNinjaDragonGaiden : Singleton<GameManager_DoubleNinjaDragonGaiden>, IGameStartCountdownListener
    {
        public GameObject gameOverCanvas;
        public TextMeshProUGUI winnerText;
        public ScoreWidget p1ScoreIcon;
        public ScoreWidget p2ScoreIcon;
        public NinjaController ninja1;
        public NinjaController ninja2;
        public CloneController clone1;
        public CloneController clone2;
        public GameObject p1KOObj;
        public GameObject p2KOObj;

        [HideInInspector] public bool isGameStarted;
        [HideInInspector] public bool isGameOver;

        private int round;
        private int p1Points;
        private int p2Points;

        private void Start()
        {
            GameStartCountdown.instance.RegisterListener(this);


            GotoNextRound();

        }

        private void Update()
        {
            if (!IsGamePlayable()) return;


        }

        public void GameStart()
        {
            clone1.ThrowSmokeBomb();
            clone2.ThrowSmokeBomb();

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

        private void GotoNextRound()
        {
            round++;

        }

        public void ScorePoint(int playerNum)
        {
            if (playerNum == 0)
            {
                p1Points++;
            }
            else if (playerNum == 1)
            {
                p2Points++;
            }

            SetScoreIcons();
        }

        public void OnNinjaDeath(int playerNum)
        {

        }

        public void OnCloneDeath(int playerNum)
        {
            if (playerNum == 0)
                clone1.gameObject.SetActive(false);
            else
                clone2.gameObject.SetActive(false);
        }

        private void SetScoreIcons()
        {
            p1ScoreIcon.SetIconCount(p1Points);
            p2ScoreIcon.SetIconCount(p2Points);
        }
    }
}
